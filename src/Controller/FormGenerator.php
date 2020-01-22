<?php
/**
 * @author Gad Ocansey<gadocansey@gmail.com>
 * Date: 17/12/2017
 * Time: 5:33 PM
 * This file is part of the admission system
 */

namespace App\Controller;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Security;
use Symfony\Bundle\FrameworkBundle\Controller\AbstractController;
use Symfony\Component\HttpFoundation\Response;
use Symfony\Component\Security\Http\Authentication\AuthenticationUtils;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Cache;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Method;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\ParamConverter;
use Symfony\Component\Security\Core\Authorization\AuthorizationCheckerInterface;
use Symfony\Component\Security\Core\Exception\AccessDeniedException;
use Symfony\Component\Security\Core\Encoder\UserPasswordEncoderInterface;
use Doctrine\ORM\EntityManagerInterface;
use  App\Entity\User as User;
use Symfony\Component\HttpFoundation\Request;
class FormGenerator extends AbstractController
{

    private $em;


    public function __construct(EntityManagerInterface $em)
    {
        $this->em = $em;

    }
    /**

     * @Route("/mailer", name="mailer")
     */
    public function indexAction( UserPasswordEncoderInterface $encoder)
    {

         ini_set('max_execution_time', 50000);
        
        $conn = $this->em->getConnection();
        for ($a=0;$a<4;$a++) {
            $pin = $this->getPin();
            $serial = $this->getSerial();

            $user = new User();

            $encoded = $encoder->encodePassword($user, $pin);

            $user->setPassword($encoded);
            $user->setFormType("HND");
            $user->setSoldBy("CAMPUS");
            $user->setSold("0");
            $user->setYear(date("Y"));
            $user->setStarted(0);

            $user->setUsername($serial);
            $user->setPin($pin);


            // 4) save the User!
            $em = $this->getDoctrine()->getManager();
            $em->persist($user);
            $em->flush();
        }

         return new Response(
        '<html><body>Voucher generated</body></html>'
    );


    }
    public function getPin(){
        $str = '59234678ABCDEFGHJKLMNPRSTUVWXY';
        $shuffled = str_shuffle($str);
        $vcode = substr($shuffled, 0, 9);
        $real = strtoupper($vcode);

        return $real;
    }
    public function getSerial(){
        $str = 'ABCDEFGHJKLMNPRSTUVWXYZ23456789';
        $shuffled = str_shuffle($str);
        $vcode = substr($shuffled, 0, 5);
        $real = strtoupper($vcode);

        return "TTU".date("y").$real;
    }
    /**
     * @Route("/foreign/applicants/apply", name="foreign")
     */
    public  function  showApplicantForeign(){

        return $this->render('foriegn/register.html.twig' );
    }

    /**
     * @Route("process_foreign", name="process_foreign")
     */
    public  function  processForeignApplicant(Request $request,UserPasswordEncoderInterface $encoder, \Swift_Mailer $mailer){

        $phone = $request->request->get('phone');
        $email = $request->request->get('email');
        $country= $request->request->get('countries');
        $name= $request->request->get('name');
        $pin=$this->getPin();
        $serial=$this->getSerial();
        $message="Hi $name, your pin code is $pin and serial is $serial. Logon to admissions.ttuportal.com to fill the admissions form. Thanks ";

        if(!empty($phone) && !empty($name) && !empty($country) && !empty($email)) {

                $user = new User();

                $encoded = $encoder->encodePassword($user, $pin);

                $user->setPassword($encoded);
                $user->setUsername($serial);
                $user->setPin($pin);
                $user->setFullName($name.' - '.$country);
                $user->setEmail($email);
                $user->setPhone($phone);
                $user->setFormType("FOREIGN");

                $em = $this->getDoctrine()->getManager();
                $em->persist($user);
                $em->flush();

            /*$mail=(new \Swift_Message('Takoradi Technical University Admissions - Ghana'))
                ->setFrom('admissions@ttuportal.com')
                ->setTo($email)
                ->setBody(
                    $message,
                    'text/plain'
                );
            $mailer->send($mail);*/

            $headers = 'MIME-Version: 1.0' . "\r\n";
            $headers .= 'Content-type: text/html; charset=iso-8859-1' . "\r\n";

            $headers = 'MIME-Version: 1.0' . "\r\n";
            $headers .= 'Content-type: text/html; charset=iso-8859-1' . "\r\n";
            $headers .= 'From: Takoradi Technical University <admissions@ttuportal.com>'. "\r\n";

            $email_message = "
               <p>Takoradi Technical University Online Admission System - Ghana</p>
    
               <p>Hello $name</p>
                
                    
                 </p>
                <p>  Your PIN code=$pin and SERIAL NO.=$serial </br> </p>
                <p>Logon to admissions.ttuportal.com to fill the application form with the pin and serial number</p>
                <p> Thank you for applying to study at Takoradi Technical University.</p>
               
                <p>This is an automatically generated email message. Please do not reply
                    to this mail directly.</p>
                    <p>If further assistance is required, please send an email to
                registrar@ttu.edu.gh</p>";
            "<p>Best regards</p>";

            @mail($email, "Takoradi Technical University Admissions", $email_message, $headers);




        }
        else{
            return $this->render('foriegn/register.html.twig' ,['message'=>'Error please fill all required fields']);
        }

        return $this->redirectToRoute('security_login');
    }

}