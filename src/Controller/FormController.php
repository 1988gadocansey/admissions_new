<?php
/*
 * This file is part of the Admission Software package.
 *
 * (c) Gad Ocansey <gadocansey@gmail.com>
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 */

namespace App\Controller;

use App\Entity\Applicant;
use App\Entity\Country;
use App\Entity\ExamResult;
use App\Form\ApplicantStepOne;
use App\Form\ApplicantStepThree;
use App\Form\ApplicantStepTwo;
use Doctrine\ORM\Mapping\Entity;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Security;
use Symfony\Bundle\FrameworkBundle\Controller\AbstractController;
use Symfony\Component\HttpFoundation\Request;
use App\Utils\ApplicantService;
use Symfony\Component\HttpFoundation\Response;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Method;

use Doctrine\Common\Persistence\ManagerRegistry;
/**
 * @Security("is_granted('ROLE_USER')")
 */
class FormController extends AbstractController
{




    /**
     * @Security("is_granted('ROLE_USER')")
     * @Route("/dashboard", name="dashboard")
     */


    public function indexAction()
    {
        $em = $this->getDoctrine()->getManager();
        $user = $this->getUser();
        $applicant = $user->getFormNo();
        $applicantID = $user->getId();
        $photo = $applicant;

        $checkIfAdmitted= $em->getRepository('App:Applicant')->findOneByApplicationNumber($applicant);
        if($checkIfAdmitted) {
            if ($checkIfAdmitted->getAdmited() == 1) {
                @$userData = $em->getRepository('App\Entity\User')->findOneByFormNo($applicant);

                @$userData->setFinalized(1);
                return $this->redirectToRoute('letter');
            }
        }


            return $this->render('dashboard/dashboard.html.twig', [
                'photo' => $photo
            ]);

    }

    /**
     * @Security("is_granted('ROLE_USER')")
     * @Route("/application/letter", name="letter")
     */
    public function LetterAction()
    {
        $em = $this->getDoctrine()->getManager();
        $user = $this->getUser();
        $applicant = $user->getFormNo();

        $data= $em->getRepository('App:Applicant')->findAdmittedApplicant($applicant);
            //var_dump($data);

        if($data) {
            /*if ($data->getAdmissionType() == "regular") {


                return $this->render('letter/letter.html.twig', [
                    'data' => $data
                ]);
            } elseif ($data->getAdmissionType() == "conditional") {
                return $this->render('letter/letter.html.twig', [
                    'data' => $data
                ]);
            }
            elseif ($data->getAdmissionType() == "mature") {
                return $this->render('letter/mature.html.twig', [
                    'data' => $data
                ]);
            }
            elseif ($data->getAdmissionType() == "technical") {
                return $this->render('letter/technical.html.twig', [
                    'data' => $data
                ]);
            }*/
            $id=$data->getId();
            $url="http://45.33.4.164/admissions/1040/letter/print/";

            return $this->redirect("http://45.33.4.164/admissions/$id/letter/print/");
        }
        else{
            return $this->redirectToRoute('dashboard');
        }

    }



    /**
     * @Route("/form/step1", name="step1")
     */
    public function step1(Request $request, ApplicantService $helper)
    {
        $user = $this->getUser();
        $formNo = $user->getFormNo();
        if($user->getFinalized()==1){
            return $this->redirectToRoute('preview');
        }
        $em = $this->getDoctrine()->getManager();
        $user = $this->getUser();
        $formNo = $user->getFormNo();
        $pin = $user->getPin();
        $form_Id = $user->getId();
        $formType = $user->getFormType();
        /*
         * check if applicant exist before persisting to DB
         */
        $existingApplicant = $em->getRepository('App:Applicant')->findOneByApplicationNumber($formNo);
        //dump($existingApplicant->getId());die();
        $applicant = new Applicant();

        $form = $this->createForm(ApplicantStepOne::class, $applicant, array(
            'user' => $formNo,
            'type'=>$formType
        ));

        $form->handleRequest($request);

        if ($form->isSubmitted() && $form->get('firstName')->isValid()) {
            if (!$existingApplicant) {
                $applicant = new Applicant();
                $applicant->setApplicationNumber($formNo);
                $applicant->setPin($pin);
                $applicant->setFormId($form_Id);
                $applicant->setFirstName(ucwords($form->get('firstName')->getData()));
                $applicant->setLastName(ucwords($form->get('lastName')->getData()));
                $applicant->setOtherNames(ucwords($form->get('otherNames')->getData()));
                $applicant->setName();
                $applicant->setGender(ucwords($form->get('gender')->getData()));
                $applicant->setTitle(ucwords($form->get('title')->getData()));
                $applicant->setAddress(ucwords($form->get('address')->getData()));
                $applicant->setHometown(ucwords($form->get('hometown')->getData()));
                $applicant->setMaritalStatus(ucwords($form->get('maritalStatus')->getData()));
                //$applicant->setDob(date("Y-m-d", strtotime($form->get('dob')->getData()->format('Y-m-d'))));
                $applicant->setDob($form->get('dob')->getData());
                $applicant->setEntryQualificationOne(ucwords($form->get('entryQualificationOne')->getData()));
                $applicant->setEntryQualificationTwo(ucwords($form->get('entryQualificationTwo')->getData()));
                $applicant->setPhysicallyDisabled(ucwords($form->get('physicallyDisabled')->getData()));
                $applicant->setPhone($form->get('phone')->getData());
                $applicant->setReligion($form->get('religion')->getData());
                $applicant->setRegion($form->get('region')->getData());
                $applicant->setAge($helper->age($form->get('dob')->getData(), 'eu'));
                $applicant->setHometown(ucwords($form->get('hometown')->getData()));
                $applicant->setEmail(ucwords($form->get('email')->getData()));
                $applicant->setBond(ucwords($form->get('bond')->getData()));

                if($form->get('region')->getData()=="None") {
                    $applicant->setNationality($form->get('nationality')->getData());
                }
                else{
                    $country = $em->getRepository('App:Country')->findOneById(239);

                    //var_dump($country->getId());
                    //dump($existingApplicant->getId());die();

                    $applicant->setNationality($country);

                }

                $applicant->setFinanceSource(ucwords($form->get('financeSource')->getData()));
                $applicant->setGuardianRelationship(ucwords($form->get('guardianRelationship')->getData()));
                $applicant->setGuardianName(ucwords($form->get('guardianName')->getData()));
                $applicant->setGuardianAddress(ucwords($form->get('guardianAddress')->getData()));
                $applicant->setGuardianPhone(ucwords($form->get('guardianPhone')->getData()));
                $applicant->setGuardianOccupation(ucwords($form->get('guardianOccupation')->getData()));

                $applicant->setStatus();
                $applicant->setAdmited();
                $applicant->setFormCompleted(0);
                $applicant->setYearOfAdmission(date('Y')."/".(date("Y")+1));
                $applicant->setFormType(ucwords($formType));
                $applicant->setLetterPrinted(0);
                $applicant->setEntryMode(ucwords($helper->entryType($formType)));
                //$applicant->setCreatedAt(new \DateTime());
                //$applicant->setUpdatedAt(new \DateTime());


                $em->persist($applicant);
            } else {

                $applicant = $em->getRepository('App:Applicant')->findOneByApplicationNumber($formNo);
                $applicant->setFirstName(ucwords($form->get('firstName')->getData()));
                $applicant->setLastName(ucwords($form->get('lastName')->getData()));
                $applicant->setOtherNames(ucwords($form->get('otherNames')->getData()));

                $applicant->setName();
                $applicant->setGender(ucwords($form->get('gender')->getData()));
                $applicant->setTitle(ucwords($form->get('title')->getData()));
                $applicant->setAddress(ucwords($form->get('address')->getData()));
                $applicant->setHometown(ucwords($form->get('hometown')->getData()));
                $applicant->setMaritalStatus(ucwords($form->get('maritalStatus')->getData()));
                $applicant->setDob($form->get('dob')->getData());
                $applicant->setEntryQualificationOne(ucwords($form->get('entryQualificationOne')->getData()));
                $applicant->setEntryQualificationTwo(ucwords($form->get('entryQualificationTwo')->getData()));
                $applicant->setPhysicallyDisabled(ucwords($form->get('physicallyDisabled')->getData()));
                $applicant->setPhone($form->get('phone')->getData());
                $applicant->setReligion($form->get('religion')->getData());
                $applicant->setRegion($form->get('region')->getData());
                $applicant->setDenomination($form->get('religion')->getData());
                $applicant->setAge($helper->age($form->get('dob')->getData(), 'eu'));
                $applicant->setHometown(ucwords($form->get('hometown')->getData()));
                $applicant->setEmail(ucwords($form->get('email')->getData()));
                $applicant->setBond(ucwords($form->get('bond')->getData()));

                if($form->get('region')->getData()=="None") {
                    $applicant->setNationality($form->get('nationality')->getData());
                }
                else{
                    $country = $em->getRepository('App:Country')->findOneById(239);

                    //var_dump($country->getId());
                    //dump($existingApplicant->getId());die();

                    $applicant->setNationality($country);

                }



                $applicant->setFinanceSource(ucwords($form->get('financeSource')->getData()));
                $applicant->setGuardianRelationship(ucwords($form->get('guardianRelationship')->getData()));
                $applicant->setGuardianName(ucwords($form->get('guardianName')->getData()));
                $applicant->setGuardianAddress(ucwords($form->get('guardianAddress')->getData()));
                $applicant->setGuardianPhone(ucwords($form->get('guardianPhone')->getData()));
                $applicant->setGuardianOccupation(ucwords($form->get('guardianOccupation')->getData()));

                $applicant->setStatus();
                $applicant->setAdmited();
                $applicant->setFormCompleted(0);
                $applicant->setYearOfAdmission(date('Y')."/".(date("Y")+1));
                $applicant->setFormType(ucwords($formType));
                $applicant->setLetterPrinted(0);
                $applicant->setEntryMode(ucwords($helper->entryType($formType)));
                //$applicant->setCreatedAt(new \DateTime());
               // $applicant->setUpdatedAt(new \DateTime());


                $em->persist($applicant);
            }
            $em->flush();

            $this->addFlash('success', 'Step 1 completed!');
            #return $this->redirectToRoute('step1');
            return  $this->redirectToRoute('step1', array('done' => 1));
        }


        return $this->render('step1/form.html.twig', array(
            'form' => $form->createView(),
            'data' => $existingApplicant,
            'type'=>$formType

        ));
    }

    /**
     * @Route("/form/step2", name="step2")
     */
    public function step2(Request $request, ApplicantService $helper)
    {
        $user = $this->getUser();
        $formNo = $user->getFormNo();
        if($user->getFinalized()==1){
            return $this->redirectToRoute('preview');
        }
        $em = $this->getDoctrine()->getManager();
        $user = $this->getUser();
        $type = $user->getFormType();

        $applicant = $em->getRepository('App:Applicant')->findOneByApplicationNumber($formNo);

        //dd($applicant);


        $form = $this->createForm(ApplicantStepTwo::class, $applicant, array(
            'user' => $formNo,
            'type'=>$type,


        ));

        $form->handleRequest($request);
        /*
         * check if applicant exist before persisting to DB
         */
        if ($form->isSubmitted() && $form->get('programmeStudied')->isValid()) {


            $applicant->setPreferedHall(ucwords($form->get('preferedHall')->getData()));
            $applicant->setFormerSchool($form->get('formerSchool')->getData());
           /* if ($user->getFormType() == "MTECH" || $user->getFormType() == "BTECH") {
                $applicant->setClass($form->get('class')->getData());
            }*/
            $applicant->setProgrammeStudied(ucwords($form->get('programmeStudied')->getData()));
            $applicant->setReferrals(ucwords($form->get('referrals')->getData()));
            $applicant->setAwaiting(ucwords($form->get('awaiting')->getData()));
                //die($form->get('referrals')->getData());
            //$applicant->setCreatedAt(new \DateTime());
            //$applicant->setUpdatedAt(new \DateTime());


            $em->persist($applicant);

            $em->flush();

            $this->addFlash('success', 'Data saved successfully - Step 2 completed!');
            #return $this->redirectToRoute('step2');
            return  $this->redirectToRoute('step2', array('done' => 2));

        }
        /*
            *  Lets update the applicant detail as completed
            */
        $userData = $em->getRepository('App\Entity\User')->findOneByFormNo($formNo);

        $userData->setFormCompleted(1);

        $em->merge($userData);
        $em->flush();


        return $this->render('step2/form.html.twig', array(
            'form' => $form->createView(),
            'data' => $applicant,
            'user' => $formNo,
        ));
    }

    /**
     * @Route("/form/step3", name="step3")
     */
    public function step3(Request $request, ApplicantService $helper)
    {
        $user = $this->getUser();
        $formNo = $user->getFormNo();
        if($user->getFinalized()==1){
            return $this->redirectToRoute('preview');
        }
        $em = $this->getDoctrine()->getManager();
        $user = $this->getUser();
        $formNo = $user->getFormNo();
        $applicant = $user->getId();

        $examResult = new ExamResult();


        $form = $this->createForm(ApplicantStepThree::class, $examResult, array(
            'user' => $formNo,
        ));

        $form->handleRequest($request);
        /*
         * check if applicant exist before persisting to DB
         */
        if ($form->isSubmitted() && $form->get('center')->isValid()) {
            //die($form->get('center')->getData());
            $helper->getGradeValue($form->get('grade')->getData());
            $examResult->setApplicant($applicant);
            $examResult->setSubject($form->get('subject')->getData());
            $examResult->setExamType($form->get('examType')->getData());
            $examResult->setSitting($form->get('sitting')->getData());
            $examResult->setMonth($form->get('month')->getData());

            $examResult->setCenter($form->get('center')->getData());


            $examResult->setIndexNo($form->get('indexNo')->getData());
            $examResult->setForm($formNo);
            $examResult->setApplicant($applicant);
            $examResult->setGrade($form->get('grade')->getData());
            $examResult->setSubjectType($form->get('subject')->getData()->getType());
            $examResult->setGradeValue($helper->getGradeValue($form->get('grade')->getData()));


            $em->persist($examResult);

            $em->flush();

            /*
             *  Lets update the applicant detail as completed
             */
            $userData = $em->getRepository('App\Entity\User')->findOneByFormNo($formNo);



            $userData->setFormCompleted(1);

            $em->merge($userData);
            $em->flush();


            $this->addFlash('success', " Data saved - Step 3 completed");
            return $this->redirectToRoute('step3');

        }

        $result = $em->getRepository('App:ExamResult')->findByForm($formNo);
        //dump($result);die();
        return $this->render('step3/form.html.twig', array(
            'form' => $form->createView(),
            'data' => $result,
            'user' => $formNo,
        ));
    }

    /**
     * @Route("/form/preview", name="preview")
     *  Applicant preview admission form to print
     */
    public function preview()
    {
        $em = $this->getDoctrine()->getManager();
        $user = $this->getUser();
        $formNo = $user->getFormNo();

        $applicant = $em->getRepository('App:Applicant')->findOneByApplicationNumber($formNo);
        $result = $em->getRepository('App:ExamResult')->findByForm($formNo);
        // dump($applicant);die();
        return $this->render('step4/printout.html.twig', array(

            'data' => $applicant,
            'result' => $result,
        ));
    }

    /**
     * @Route("/complete", name="complete")
     *  Applicant preview admission form to print
     */
    public function finalized(Request $request, ApplicantService $helper)
    {
        $formsType = ["MTECH", "BTECH"];
        $em = $this->getDoctrine()->getManager();
        $user = $this->getUser();
        $formNo = $user->getFormNo();

        $applicant = $em->getRepository('App:Applicant')->findOneByApplicationNumber($formNo);
        $firstChoice = $applicant->getProgrammeID1()->getName();
        $secondChoice = $applicant->getProgrammeID2()->getName();
        $thirdChoice = $applicant->getProgrammeID3()->getName();
        $name = ucwords($applicant->getName());
        $phone = $applicant->getPhone();
        $email= $applicant->getEmail();
        $grades = $em->getRepository('App:ExamResult')->findByApplicant($formNo);
        $message = "Hi $name your application has been received by our school. Your Application number is $formNo.Congrats";

      //  dump($applicant->getFormCompleted());die();

        if (@$user->getFormCompleted() == 1) {
            if ((!in_array($user->getFormType(), $formsType)) ) {

               $userData = $em->getRepository('App\Entity\User')->findOneByFormNo($formNo);

                $userData->setFinalized(1);

                $em->merge($userData);
                $em->flush();
                @$helper->firesms($message, $phone, $phone);
            } else {
                $userData = $em->getRepository('App\Entity\User')->findOneByFormNo($formNo);

                $userData->setFinalized(1);

                $em->merge($userData);
                $em->flush();
                @$helper->firesms($message, $phone, $phone);


                $pin = $user->getPin();
                $serial = $user->getUsername();
                $headers = 'MIME-Version: 1.0' . "\r\n";
                $headers .= 'Content-type: text/html; charset=iso-8859-1' . "\r\n";

                $headers = 'MIME-Version: 1.0' . "\r\n";
                $headers .= 'Content-type: text/html; charset=iso-8859-1' . "\r\n";
                $email_message = "
               <p>Takoradi Technical University Online Admission System</p>
    
               <p>Hello $name</p>
                
              <p> <ol>
                    <li>Takoradi Technical University  has received your form you filled at the Admissions Portal \n.</br>  
                   
                </ol></p>
                <p>Your PIN code=$pin and SERIAL NO.=$serial </br> </p>
                <p> Thank you for applying to study at Takoradi Technical University.</p>
                <p>Your First Choice is $firstChoice</p>
                <p>Your Second Choice is $secondChoice</p>
                <p>Your Third Choice is $thirdChoice</p>
     
                <p>This is an automatically generated email message. Please do not reply
                    to this mail directly.</p>
                    <p>If further assistance is required, please send an email to
                registrar@ttu.edu.gh</p>";
                    "<p>Best regards</p>";

                @mail($email, "Takoradi Technical University Admissions", $email_message, $headers);
                $this->addFlash('success', 'Form submitted to Takoradi Technical University successfully.');

                return $this->redirectToRoute('preview');


            }

        }

            //$this->addFlash('error', 'please fill all the required fields in the form before finalizing it.');

            return $this->redirectToRoute('step1');

    }

    /**
     * Deletes a result entity.
     *
     * @Route("/{id}/delete", name="result_delete")
     * @Method("POST")
     * the authorization mechanism will prevent the user accessing this resource).
     */
    public function delete(Request $request, ExamResult $entityResult): Response
    {
        /* if (!$this->isCsrfTokenValid('delete', $request->request->get('token'))) {
             return $this->redirectToRoute('result_delete');
         }*/

        // Delete the tags associated with this blog post. This is done automatically
        // by Doctrine, except for SQLite (the database used in this application)
        // because foreign key support is not enabled by default in SQLite


        $em = $this->getDoctrine()->getManager();
        $em->remove($entityResult);
        $em->flush();

        $this->addFlash('success', 'result deleted successfully');

        return $this->redirectToRoute('step3');
    }
    /*
     * This method update the system to tell us the applicant has printed the letter
     */

    /**
     * @Route("/form/print/update", name="updatePrint")
     */
    public function updatePrint(Request $request)
    {
        $em = $this->getDoctrine()->getManager();
        $user = $this->getUser();
        $formNo = $user->getFormNo();

        $applicant = $em->getRepository('App:Applicant')->findOneByApplicationNumber($formNo);



        $applicant->setLetterPrinted(1);

        $em->merge($applicant);
        $em->flush();
        return $this->redirectToRoute('step3');
    }


}