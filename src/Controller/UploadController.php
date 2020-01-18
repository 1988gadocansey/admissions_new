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

use App\Utils\FileUploader;
use App\Entity\User;
use Doctrine\ORM\Mapping\Entity;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Security;
use Symfony\Bundle\FrameworkBundle\Controller\AbstractController;
use Symfony\Component\HttpFoundation\Request;
use Intervention\Image\ImageManager;
use Symfony\Component\HttpFoundation\JsonResponse;
use Psr\Log\LoggerInterface;
use Symfony\Component\HttpFoundation\Response;

class UploadController extends AbstractController
{


    /**
     * @Security("is_granted('ROLE_USER')")
     * @Route("/avatar/upload", name="photoUpload")
     */
    public function indexAction()
    {
        $user = $this->getUser();
        $applicant = $user->getFormNo();
        $applicantID = $user->getId();
        $photo = $applicant;
        return $this->render('photo/upload.html.twig', [
            'photo' => $photo
        ]);
    }


    /**
     * @Route("/avatar/upload/process", name="process_upload")
     */

    public function uploadActions(Request $request, string $uploadDir, FileUploader $uploader, LoggerInterface $logger)
    {
        $user = $this->getUser();
        $applicant = $user->getFormNo();

        //var_dump($applicant);
        $uploaded = $user->getPictureUploaded();
        $applicantID = $user->getId();

        if ($uploaded == 0) {
            $formNumber = $this->getDoctrine()->getManager()
                ->getRepository('App\Entity\FormNo')
                ->findAll();


            foreach ($formNumber as $row) {
                $applicantNumber = $row->getNumber();
            }

            $em = $this->getDoctrine()->getManager();

            $file = $request->files->get('logo-id');


            $token = $request->get("token");

            if (!$this->isCsrfTokenValid('upload', $token)) {
                $logger->info("CSRF failure");

                return new Response("Operation not allowed", Response::HTTP_BAD_REQUEST,
                    ['content-type' => 'text/plain']);
            }


            $status = "File was empty";

            // If a file was uploaded
            if (!is_null($file)) {
                // generate a random name for the file but keep the extension
                //$filename = uniqid().".".$file->getClientOriginalExtension();
                $valid_exts = array('jpg', 'JPG'); // valid extensions
                $max_size = 250000; // max file size
                //dd($file->getClientSize());
                $ext = strtolower($file->getClientOriginalExtension());
                //$ext = $file->getClientOriginalExtension();
                if (in_array($ext, $valid_exts)) {
                    //$originalFilename = pathinfo($brochureFile->getClientOriginalName(), PATHINFO_FILENAME);


                    if (filesize($file) <= $max_size) {


                        $applicantNumber = date("Y") . $applicantNumber;


                        $file = $request->files->get('logo-id');
                        $filename = $applicantNumber . "." . $ext;
                        if (empty($file)) {
                            return new \Response("No file specified",
                                Response::HTTP_UNPROCESSABLE_ENTITY, ['content-type' => 'text/plain']);
                        }


                        $uploader->upload($uploadDir, $file, $filename);

                        //return new Response("File uploaded", Response::HTTP_OK,['content-type' => 'text/plain']);

                        /*
                         * Now update the form number table and update
                         * the user table with the new application form
                         * generated
                         */
                        //\DB::update('admission_formNumber')->set(array('number' => \DB::expr('number + 1')));
                        if ($applicant == 0 && $uploaded == 0) {

                            $query = $em->createQuery("UPDATE App\Entity\FormNo form  SET form.number = form.number + 1");
                            $query->execute();


                            $userData = $em->getRepository('App\Entity\User')->findOneById($applicantID);
                            $userData->setFormNo($applicantNumber);
                            $userData->setStarted(1);
                            $userData->setPictureUploaded(1);
                            $em->merge($userData);
                            $em->flush();
                        }

                        $status = "Photo uploaded successfully";
                        /*
                         * Now updating user table to reflect the user
                         * has started his application and uploaded his
                         * passport photo
                         */


                    } else {
                        $status = "Photo size must not exceed 250kb";
                    }

                } else {
                    $status = "Upload only jpeg photo";
                }


            }
            $photo = $applicant;
            return $this->render('photo/upload.html.twig', [
                'status' => $status,
                'photo' => $photo
            ]);
        } else {


            $token = $request->get("token");

            if (!$this->isCsrfTokenValid('upload', $token)) {
                $logger->info("CSRF failure");

                return new Response("Operation not allowed", Response::HTTP_BAD_REQUEST,
                    ['content-type' => 'text/plain']);
            }

            $user = $this->getUser();
            $applicant = $user->getFormNo();
            $uploaded = $user->getPictureUploaded();
            $applicantID = $user->getId();


            $em = $this->getDoctrine()->getManager();

            $file = $request->files->get('logo-id');

            $valid_exts = array('jpg', 'JPG'); // valid extensions
            $max_size = 250000; // max file size
            $ext = strtolower($file->getClientOriginalExtension());

            if (in_array($ext, $valid_exts)) {


                if (@filesize($file) <= $max_size) {


                    $applicantNumber = $applicant;


                    $file = $request->files->get('logo-id');
                    $filename = $applicantNumber . "." . $ext;
                    if (empty($file)) {
                        return new \Response("No file specified",
                            Response::HTTP_UNPROCESSABLE_ENTITY, ['content-type' => 'text/plain']);
                    }


                    $uploader->upload($uploadDir, $file, $filename);

                    //return new Response("File uploaded", Response::HTTP_OK,['content-type' => 'text/plain']);
                    $status = "Photo uploaded successfully";
                } else {
                    $status = "The size of the photo must not exceed 250kb";
                }
            } else {
                $status = "Upload only jpeg photo";
            }

            $photo = $applicant;
            return $this->redirectToRoute("photoUpload");
        }
    }
}