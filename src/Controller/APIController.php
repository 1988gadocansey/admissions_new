<?php
/**
 * Created by PhpStorm.
 * User: gadoo
 * Date: 06/08/2018
 * Time: 5:33 PM
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
use App\Helpers\ApplicantService;
use Symfony\Component\HttpFoundation\Response;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Method;




class APIController extends AbstractController
{
    /**
     * @Route("/api/form/{applicant}", name="preview_call")
     *  Applicant preview admission form to print
     * @Security("is_granted('IS_AUTHENTICATED_ANONYMOUSLY')")
     */
    public function previewCall(Request $request, $applicant)
    {

        $em = $this->getDoctrine()->getManager();
        $user = $this->getUser();
        $formNo = $applicant;

        $applicant = $em->getRepository('App:Applicant')->findOneByApplicationNumber($formNo);
        $result = $em->getRepository('App:ExamResult')->findByForm($formNo);
        // dump($applicant);die();
        return $this->render('step4/printout_django.html.twig', array(

            'data' => $applicant,
            'result' => $result,
        ));
    }
}