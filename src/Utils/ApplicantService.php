<?php
/*
 * This file is part of the Admission Software package.
 *
 * (c) Gad Ocansey <gadocansey@gmail.com>
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 */

namespace App\Utils;

use Sensio\Bundle\FrameworkExtraBundle\Configuration\Security;
use Doctrine\ORM\EntityManagerInterface;
use App\Entity\Sms;

/**
 * @Security("is_granted('ROLE_USER')")
 */
class ApplicantService
{
    private $em;


    public function __construct(EntityManagerInterface $em)
    {
        $this->em = $em;

    }
    public function entryType($formType){
        $types=array("HND"=>"Direct","BTECH"=>'Direct',"MTECH"=>'Direct',"MATURE"=>'Mature',"FOREIGN"=>"INTERNATIONAL APPLICANT");

        foreach ($types as $key=>$row){
            if($key==$formType) return $row;

        }

    }
    public function age($birthdate, $pattern = 'eu') {
        $patterns = array(
            'eu' => 'd/m/Y',
            'mysql' => 'Y-m-d',
            'us' => 'm/d/Y',
            'gh' => 'd-m-Y',
        );

        $now = new \DateTime();
        $in = \DateTime::createFromFormat($patterns[$pattern], $birthdate);
        $interval = $now->diff($in);
        return $interval->y;
    }


    public function getGradeValue($grade) {

        $conn = $this->em->getConnection();
        $sql = "SELECT value FROM admissions_waec_grades WHERE grade='$grade'";
        $stmt = $conn->prepare($sql);
        $stmt->execute();

        $data=$stmt->fetchAll();
        foreach ($data as $row){
            $value=$row['value'];
        }
       return $value ;
    }


    public function firesms($message,$phone,$receipient){


        if (!empty($phone)&& !empty($message)&& !empty($receipient)) {




                $phone="+233".\substr($phone,1,9);
                $phone = str_replace(' ', '', $phone);
                $phone = str_replace('-', '', $phone);
                if (!empty($message) && !empty($phone)) {

                    #$key = "bcb86ecbc1a058663a07"; //your unique API key;
                    $key = "bcb86ecbc1a058663a07"; //your unique API key;

                    // $sender_id="TTU";




                    $message=urlencode($message); //encode url;
                    $sender_id="TTU";

                    $url = "http://sms.gadeksystems.com/smsapi?key=$key&to=$phone&msg=$message&sender_id=$sender_id";



                    $ch = \curl_init();
                    \curl_setopt($ch, CURLOPT_URL, $url);
                    \curl_setopt($ch, CURLOPT_HEADER, 0);
                    \curl_setopt($ch, CURLOPT_RETURNTRANSFER, TRUE);
                    $result = \curl_exec($ch);
                    \curl_close($ch);

                    $result="Message was successfully sent";

/*
                    $this->em = $this->em->getConnection();
                    $user = $this->getUser();
                    $formNo = $user->getFormNo();

                    $sms = new Sms();
                    $sms->setStatus($result);
                    $sms->setMessage($message);
                    $sms->setPhone($phone);
                    $sms->setSender($formNo);
                    $sms->setReceipient($formNo);
                    $sms->setDateSent(\DateTime::class);
                    $sms->setType("Admissions Notification");
                    $this->em->persist($sms);*/
                }


        }


        return 0;
    }
    /*
     * @param array of grades
     * count the number of failed subjects
     */
    public function CountFails($array){
        $fail=0;

        foreach($array AS $value){
            // echo "value:$value</br>";
            if($value>7){

                $fail++;
            }


        }
        return $fail;

    }
    // list the total failed and passed subjects
    public function CheckFails($applicant){
        $subject_array_core=array();
        $subject_array_core_alt=array();
        $subject_array_elect=array();
        $form= $applicant;
        $qualification=array("WASSSCE","SSSCE","NAPTEX","TEU");
        // $query=  mysql_query("SELECT APP_FORM,ENTRY_TYPE,FIRST_CHOICE FROM tbl_applicants WHERE   APP_FORM='$form' ");
        $query=@Models\ApplicantModel::where("APPLICATION_NUMBER", $form)->get();


        foreach($query as $row){
            if(in_array($row->ENTRY_QUALIFICATION, $qualification)){
                $resultQuery=@Models\ExamResultsModel::where("APPLICATION_NUMBER", $form)->orderBy("GRADE_VALUE","DESC")->get();

                foreach($resultQuery as $value){
                    if($value->TYPE=='core'){
                        @$subject_array_core[@$value->subject->NAME]=@$value->GRADE_VALUE;
                    }
                    elseif($value->TYPE=='core_alt'){
                        $subject_array_core_alt[@$value->subject->NAME]=@$value->GRADE_VALUE;
                    }
                    else{
                        $subject_array_elect[@$value->subject->NAME]=@$value->GRADE_VALUE;
                    }
                }

                if(count($subject_array_core)<2){$error="Core Subjects not met. minimum pass of two compulsory cores i.e Core Maths and English<br/>"; $qualify="No"; }

                if(count($subject_array_core_alt)==0){$error.="Core  Alternative Subject not met. Either pass in Social studies or Integrated Science <br/>"; $qualify="No"; }

                if(count($subject_array_core)+count($subject_array_core_alt)+count($subject_array_elect)!=6){$error.="Passes in at least 6 subjects required <br/>"; $qualify="No";}

                @sort($subject_array_core_alt);  @sort($subject_array_core);   @sort($subject_array_elect);

                $elective_slice=  @array_slice($subject_array_elect, 0,3);
                $core_alt_slice=  @array_slice($subject_array_core_alt, 0,1);

                $grade=  (  array_sum($subject_array_core) +  array_sum($elective_slice)+ array_sum($core_alt_slice));

                $total=  $this->CountFails($subject_array_core)+ $this->CountFails($elective_slice) + $this->CountFails($core_alt_slice);

                if ($qualify == "Yes") {
                    $status = "Qualify?" . $qualify . " - " . " Total Failed: " . $total;
                } else {
                    $status = "Qualify?" . $qualify . " - " . $error . " - " . " Total Failed: " . $total;
                }

                return    mysql_query("UPDATE tbl_applicants SET STATUS='$status' , GRADE='$grade' WHERE APP_FORM='$form'");

                @Models\ApplicantModel::where("APPLICATION_NUMBER", $form)->update(array("ELIGIBILTY"=>$status,"QUALIFY"=>$qualify,"GRADE"=>$grade));

            } else{
                $qualify="Yes";
            }
        }

    }
}