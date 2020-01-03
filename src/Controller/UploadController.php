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
use App\Utils\ImageHelper;
use App\Entity\User;
use Doctrine\ORM\Mapping\Entity;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Security;
use Symfony\Bundle\FrameworkBundle\Controller\AbstractController;
use Symfony\Component\HttpFoundation\Request;
use Intervention\Image\ImageManager;
use Symfony\Component\HttpFoundation\JsonResponse;

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


//    public function uploadAction(Request $request)
//    {
//
//        $user = $this->getUser();
//        $applicant = $user->getFormNo();
//        $applicantID = $user->getId();
//        $formNumber = $this->getDoctrine()->getManager()
//            ->getRepository('App\Entity\FormNo')
//            ->findAll();
//        foreach ($formNumber as $row) {
//            $applicantNumber = $row->getNumber();
//        }
//        $em = $this->getDoctrine()->getManager();
//
//        $file = $request->files->get('logo-id');
//
//
//        $status = "File was empty";
//
//        // If a file was uploaded
//        if (!is_null($file)) {
//            // generate a random name for the file but keep the extension
//            //$filename = uniqid().".".$file->getClientOriginalExtension();
//            $valid_exts = array( 'jpg', 'JPG'); // valid extensions
//            $max_size = 300000; // max file size
//            $ext = strtolower($file->getClientOriginalExtension());
//            //$ext = $file->getClientOriginalExtension();
//            if (in_array($ext, $valid_exts)) {
//                /*
//                 *  check if the image is landscape and reject it
//                 *  NB we prefer only portrait with correct aspect
//                 *  ratios
//                 */
//               // $image = new \Imagick($file);
//               // ImageHelper::autoRotateImage($image);
//                $mode=ImageHelper::checkOrientation($file);
//
//                //var_dump($mode);
//
//                if( $mode=='horizontal') {
//                    $status = "Please upload only portrait photograph";
//                    $orientation = "Landscape";
//
//                }
//                else {
//                     $orientation = "portrait";
//
//
//                    if ($file->getClientSize() <= $max_size) {
//                        $path = 'public/albums/thumbnails';
//
//                        /**
//                         * get new form no for applicant
//                         * update the user status as photo uploaded
//                         **/
//
//
//                        $applicantNumber = date("Y") . $applicantNumber;
//
//                        $filename = $applicantNumber . "." . $ext;
//                          /*
//                         * Now $applicantNumber is the applicant form number
//                         * on his application form
//                         * after the upload of photo operation update the db
//                         */
//                        /*
//                       *  Crop and resize the uploaded photo
//                       *
//                       */
//                        $newPath=$path.'/'.$filename;
//                        $photoBeforeResize=ImageHelper::resize_crop_image("345","435",$file,$newPath);
//
//                        $file->move($path, $photoBeforeResize); // move the file to a path
//
//                        /*
//                         * Now update the form number table and update
//                         * the user table with the new application form
//                         * generated
//                         */
//                        //\DB::update('admission_formNumber')->set(array('number' => \DB::expr('number + 1')));
//                        if ($applicant ==0) {
//
//                            $query = $em->createQuery("UPDATE App\Entity\FormNo form  SET form.number = form.number + 1");
//                            $query->execute();
//
//
//                            $userData = $em->getRepository('App\Entity\User')->findOneById($applicantID);
//                            $userData->setFormNo($applicantNumber);
//                            $userData->setStarted(1);
//                            $userData->setPictureUploaded(1);
//                            $em->merge($userData);
//                            $em->flush();
//                        }
//                        $status = "Photo uploaded successfully";
//
//                        /*
//                         * Now updating user table to reflect the user
//                         * has started his application and uploaded his
//                         * passport photo
//                         */
//
//
//                    } else {
//                        $status = "photo size is less than or equal 300kb";
//                    }
//                }
//            } else {
//                $status = "Upload only jpeg photo";
//            }
//
//        }
//        $photo = $applicant;
//        return $this->render('photo/upload.html.twig', [
//            'status' => $status,
//            'photo' => $photo
//        ]);
//    }
    /**
     * @Route("/avatar/upload/process", name="process_upload")
     */
    public function uploadAction(Request $request)
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


            $status = "File was empty";

            // If a file was uploaded
            if (!is_null($file)) {
                // generate a random name for the file but keep the extension
                //$filename = uniqid().".".$file->getClientOriginalExtension();
                $valid_exts = array('jpg', 'JPG'); // valid extensions
                $max_size = 500000; // max file size
                //dd($file->getClientSize());
                $ext = strtolower($file->getClientOriginalExtension());
                //$ext = $file->getClientOriginalExtension();
                if (in_array($ext, $valid_exts)) {
                    //$originalFilename = pathinfo($brochureFile->getClientOriginalName(), PATHINFO_FILENAME);


                    if (filesize($file)<=$max_size) {
                        $path = 'public/albums/thumbnails';

                        /**
                         * get new form no for applicant
                         * update the user status as photo uploaded
                         **/


                        $applicantNumber = date("Y") . $applicantNumber;
                        //$applicantNumber = "2019" . $applicantNumber;

                        $filename = $applicantNumber . "." . $ext;
                        /*
                       * Now $applicantNumber is the applicant form number
                       * on his application form
                       * after the upload of photo operation update the db
                       */
                        /*
                       *  Crop and resize the uploaded photo
                       *
                       */
                        $newPath = $path . '/' . $filename;

                        //s$photoBeforeResize = ImageHelper::resize_crop_image("345", "435", $file, $newPath);



                        $file->move($path, $newPath);


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
                        $status = "photo size is less than or equal 300kb";
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
            $user = $this->getUser();
            $applicant = $user->getFormNo();
            $uploaded = $user->getPictureUploaded();
            $applicantID = $user->getId();


                $em = $this->getDoctrine()->getManager();

                $file = $request->files->get('logo-id');

            $applicantNumber=$applicant;
                $status = "File was empty";

                // If a file was uploaded
                if (!is_null($file)) {
                    // generate a random name for the file but keep the extension
                    //$filename = uniqid().".".$file->getClientOriginalExtension();
                    $valid_exts = array('jpg', 'JPG'); // valid extensions
                    $max_size =  500000; // max file size
                    $ext = strtolower($file->getClientOriginalExtension());
                    //$ext = $file->getClientOriginalExtension();
                    if (in_array($ext, $valid_exts)) {


                        if (@filesize($file) <= $max_size) {
                            $path = 'albums/thumbnails';

                            /**
                             * get new form no for applicant
                             * update the user status as photo uploaded
                             **/


                            $filename = $applicantNumber . "." . $ext;
                            /*
                           * Now $applicantNumber is the applicant form number
                           * on his application form
                           * after the upload of photo operation update the db
                           */
                            /*
                           *  Crop and resize the uploaded photo
                           *
                           */
                            $newPath = $path . '/' . $filename;
                            $photoBeforeResize = ImageHelper::resize_crop_image("345", "435", $file, $newPath);


                            $file->move($path, $photoBeforeResize);



                            $status = "Photo uploaded successfully";
                            /*
                             * Now updating user table to reflect the user
                             * has started his application and uploaded his
                             * passport photo
                             */


                        } else {
                            $status = "photo size is less than or equal 300kb";
                        }

                    } else {
                        $status = "Upload only jpeg photo";
                    }


                }
                $photo = $applicant;
               return $this->redirectToRoute("photoUpload");
        }

    }
}