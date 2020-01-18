<?php

/*
 * This file is part of the Admission Software package.
 *
 * (c) Gad Ocansey <gadocansey@gmail.com>
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 */

namespace App\Entity;

use Doctrine\ORM\Mapping as ORM;
use Symfony\Component\Validator\Constraints as Assert;
use Doctrine\Common\Collections\ArrayCollection;
use Doctrine\Common\Collections\Collection;

/**
 * @ORM\Entity(repositoryClass="App\Repository\ApplicantRepository")
 * @ORM\Table(name="admissions_applicants")
 * @ORM\HasLifecycleCallbacks()
 * Defines the properties of the User entity to represent the application users.
 * See https://symfony.com/doc/current/book/doctrine.html#creating-an-entity-class
 *
 * Tip: if you have an existing database, you can generate these entity class automatically.
 * See https://symfony.com/doc/current/cookbook/doctrine/reverse_engineering.html
 *
 *
 *
 */

class Applicant implements  \Serializable
{

    /**
     * @return mixed
     */
    public function getId()
    {
        return $this->id;
    }

    /**
     * @param mixed $id
     */
    public function setId($id)
    {
        $this->id = $id;
    }

    public function setHometown($hometown){
        $this->hometown=$hometown;

    }

    public function getHometown(){
        return $this->hometown;
    }

    /**
     * @return mixed
     */
    public function getPin()
    {
        return $this->pin;
    }

    /**
     * @param mixed $pin
     */
    public function setPin($pin)
    {
        $this->pin = $pin;
    }

    /**
     * @return mixed
     */
    public function getApplicationNumber()
    {
        return $this->applicationNumber;
    }

    /**
     * @param mixed $applicationNumber
     */
    public function setApplicationNumber($applicationNumber)
    {
        $this->applicationNumber = $applicationNumber;
    }

    /**
     * @return mixed
     */
    public function getFirstName()
    {
        return $this->firstName;
    }

    /**
     * @param mixed $firstName
     */
    public function setFirstName($firstName)
    {
        $this->firstName = $firstName;
    }

    /**
     * @return mixed
     */
    public function getOtherNames()
    {
        return $this->otherNames;
    }

    /**
     * @param mixed $otherNames
     */
    public function setOtherNames($otherNames)
    {
        $this->otherNames = $otherNames;
    }

    /**
     * @return mixed
     */
    public function getLastName()
    {
        return $this->lastName;
    }

    /**
     * @param mixed $lastName
     */
    public function setLastName($lastName)
    {
        $this->lastName = $lastName;
    }

    /**
     * @return mixed
     */
    public function getTitle()
    {
        return $this->title;
    }

    /**
     * @param mixed $title
     */
    public function setTitle($title)
    {
        $this->title = $title;
    }

    /**
     * @return mixed
     */
    public function getName()
    {
        return $this->name;
    }

    /**
     * @param mixed $name
     */
    public function setName()
    {
        $this->name = $this->getLastName().' '.$this->getFirstName().' '.$this->getOtherNames();
    }

    /**
     * @return mixed
     */
    public function getGender()
    {
        return $this->gender;
    }

    /**
     * @param mixed $gender
     */
    public function setGender($gender)
    {
        $this->gender = $gender;
    }

    /**
     * @return mixed
     */
    public function getDob()
    {
        return $this->dob;
    }

    /**
     * @param mixed $dob
     */
    public function setDob(  $dob)
    {
        $this->dob = $dob;
    }

    /**
     * @return mixed
     */
    public function getAge()
    {
        return $this->age;
    }

    /**
     * @param mixed $age
     */
    public function setAge($age)
    {
        $this->age = $age;
    }

    /**
     * @return mixed
     */
    public function getReligion()
    {
        return $this->religion;
    }

    /**
     * @param mixed $religion
     */
    public function setReligion($religion)
    {
        $this->religion = $religion;
    }

    /**
     * @return mixed
     */
    public function getDenomination()
    {
        return $this->denomination;
    }

    /**
     * @param mixed $denomination
     */
    public function setDenomination($denomination)
    {
        $this->denomination = $denomination;
    }

    /**
     * @return mixed
     */
    public function getPhone()
    {
        return $this->phone;
    }

    /**
     * @param mixed $phone
     */
    public function setPhone($phone)
    {
        $this->phone = $phone;
    }

    /**
     * @return mixed
     */
    public function getMaritalStatus()
    {
        return $this->maritalStatus;
    }

    /**
     * @param mixed $maritalStatus
     */
    public function setMaritalStatus($maritalStatus)
    {
        $this->maritalStatus = $maritalStatus;
    }

    /**
     * @return mixed
     */
    public function getNationality()
    {
        return $this->nationality;
    }

    /**
     * @param mixed $nationality
     */
    public function setNationality(Country$nationality)
    {
        $this->nationality = $nationality;
    }

    /**
     * @return mixed
     */
    public function getEmail()
    {
        return $this->email;
    }

    /**
     * @param mixed $email
     */
    public function setEmail($email)
    {
        $this->email = $email;
    }

    /**
     * @return mixed
     */
    public function getAddress()
    {
        return $this->address;
    }

    /**
     * @param mixed $address
     */
    public function setAddress($address)
    {
        $this->address = $address;
    }

    /**
     * @return mixed
     */
    public function getPhysicallyDisabled()
    {
        return $this->physicallyDisabled;
    }

    /**
     * @param mixed $physicallyDisabled
     */
    public function setPhysicallyDisabled($physicallyDisabled)
    {
        $this->physicallyDisabled = $physicallyDisabled;
    }

    /**
     * @return mixed
     */
    public function getDisabilty()
    {
        return $this->disabilty;
    }

    /**
     * @param mixed $disabilty
     */
    public function setDisabilty($disabilty)
    {
        $this->disabilty = $disabilty;
    }

    /**
     * @return mixed
     */
    public function getAdmittedBy()
    {
        return $this->admittedBy;
    }

    /**
     * @param mixed $admittedBy
     */
    public function setAdmittedBy($admittedBy)
    {
        $this->admittedBy = $admittedBy;
    }

    /**
     * @return mixed
     */
    public function getGuardianName()
    {
        return $this->guardianName;
    }

    /**
     * @param mixed $guardianName
     */
    public function setGuardianName($guardianName)
    {
        $this->guardianName = $guardianName;
    }

    /**
     * @return mixed
     */
    public function getGuardianPhone()
    {
        return $this->guardianPhone;
    }

    /**
     * @param mixed $guardianPhone
     */
    public function setGuardianPhone($guardianPhone)
    {
        $this->guardianPhone = $guardianPhone;
    }

    /**
     * @return mixed
     */
    public function getGuardianAddress()
    {
        return $this->guardianAddress;
    }

    /**
     * @param mixed $guardianAddress
     */
    public function setGuardianAddress($guardianAddress)
    {
        $this->guardianAddress = $guardianAddress;
    }

    /**
     * @return mixed
     */
    public function getGuardianOccupation()
    {
        return $this->guardianOccupation;
    }

    /**
     * @param mixed $guardianOccupation
     */
    public function setGuardianOccupation($guardianOccupation)
    {
        $this->guardianOccupation = $guardianOccupation;
    }

    /**
     * @return mixed
     */
    public function getGuardianRelationship()
    {
        return $this->guardianRelationship;
    }

    /**
     * @param mixed $guardianRelationship
     */
    public function setGuardianRelationship($guardianRelationship)
    {
        $this->guardianRelationship = $guardianRelationship;
    }

    /**
     * @return mixed
     */
    public function getFinanceSource()
    {
        return $this->financeSource;
    }

    /**
     * @param mixed $financeSource
     */
    public function setFinanceSource($financeSource)
    {
        $this->financeSource = $financeSource;
    }

    /**
     * @return mixed
     */
    public function getFormerSchool()
    {
        return $this->formerSchool;
    }

    /**
     * @param mixed $formerSchool
     */
    public function setFormerSchool($formerSchool)
    {
        $this->formerSchool = $formerSchool;
    }

    /**
     * @return mixed
     */
    public function getProgrammeStudied()
    {
        return $this->programmeStudied;
    }

    /**
     * @param mixed $programmeStudied
     */
    public function setProgrammeStudied($programmeStudied)
    {
        $this->programmeStudied = $programmeStudied;
    }


    /**
     * @return mixed
     */
    public function getAward()
    {
        return $this->award;
    }

    /**
     * @param mixed $award
     */
    public function setAward($award)
    {
        $this->award = $award;
    }

    /**
     * @return mixed
     */
    public function getEntryMode()
    {
        return $this->entryMode;
    }

    /**
     * @param mixed $entryMode
     */
    public function setEntryMode($entryMode)
    {
        $this->entryMode = $entryMode;
    }

    /**
     * @return mixed
     */
    public function getFormType()
    {
        return $this->formType;
    }

    /**
     * @param mixed $formType
     */
    public function setFormType($formType)
    {
        $this->formType = $formType;
    }

    /**
     * @return mixed
     */
    public function getPreferedHall()
    {
        return $this->preferedHall;
    }

    /**
     * @param mixed $preferedHall
     */
    public function setPreferedHall($preferedHall)
    {
        $this->preferedHall = $preferedHall;
    }

    /**
     * @return mixed
     */
    public function getYearOfAdmission()
    {
        return $this->yearOfAdmission;
    }

    /**
     * @param mixed $yearOfAdmission
     */
    public function setYearOfAdmission($yearOfAdmission)
    {
        $this->yearOfAdmission = $yearOfAdmission;
    }

    /**
     * @return mixed
     */
    public function getEntryQualificationOne()
    {
        return $this->entryQualificationOne;
    }

    /**
     * @param mixed $entryQualificationOne
     */
    public function setEntryQualificationOne($entryQualificationOne)
    {
        $this->entryQualificationOne = $entryQualificationOne;
    }

    /**
     * @return mixed
     */
    public function getEntryQualificationTwo()
    {
        return $this->entryQualificationTwo;
    }

    /**
     * @param mixed $entryQualificationTwo
     */
    public function setEntryQualificationTwo($entryQualificationTwo)
    {
        $this->entryQualificationTwo = $entryQualificationTwo;
    }

    /**
     * @return mixed
     */
    public function getGrade()
    {
        return $this->grade;
    }

    /**
     * @param mixed $grade
     */
    public function setGrade($grade)
    {
        $this->grade = $grade;
    }

    /**
     * @return mixed
     */
    public function getBond()
    {
        return $this->bond;
    }

    /**
     * @param mixed $bond
     */
    public function setBond($bond)
    {
        $this->bond = $bond;
    }

    /**
     * @return mixed
     */
    public function getQualify()
    {
        return $this->qualify;
    }

    /**
     * @param mixed $qualify
     */
    public function setQualify($qualify)
    {
        $this->qualify = $qualify;
    }

    /**
     * @return mixed
     */
    public function getResults()
    {
        return $this->results;
    }

    /**
     * @param mixed $results
     */
    public function setResults($results)
    {
        $this->results = $results;
    }

    /**
     * @return mixed
     */
    public function getStatus()
    {
        return $this->status;
    }

    /**
     * @param mixed $status
     */
    public function setStatus()
    {
        $this->status ="Applicant";
    }

    /**
     * @return mixed
     */
    public function getAdmited()
    {
        return $this->admited;
    }

    /**
     * @param mixed $admited
     */
    public function setAdmited()
    {
        $this->admited = 0;
    }

    /**
     * @return mixed
     */
    public function getProgrammeAdmitted()
    {
        return $this->programmeAdmitted;
    }

    /**
     * @param mixed $programmeAdmitted
     */
    public function setProgrammeAdmitted($programmeAdmitted)
    {
        $this->programmeAdmitted = $programmeAdmitted;
    }

    /**
     * @return mixed
     */
    public function getHallAdmitted()
    {
        return $this->hallAdmitted;
    }

    /**
     * @param mixed $hallAdmitted
     */
    public function setHallAdmitted($hallAdmitted)
    {
        $this->hallAdmitted = $hallAdmitted;
    }

    /**
     * @return mixed
     */
    public function getDateAdmitted()
    {
        return $this->dateAdmitted;
    }

    /**
     * @param mixed $dateAdmitted
     */
    public function setDateAdmitted($dateAdmitted)
    {
        $this->dateAdmitted = $dateAdmitted;
    }

    /**
     * @return mixed
     */
    public function getSectionAdmitted()
    {
        return $this->sectionAdmitted;
    }

    /**
     * @param mixed $sectionAdmitted
     */
    public function setSectionAdmitted($sectionAdmitted)
    {
        $this->sectionAdmitted = $sectionAdmitted;
    }

    /**
     * @return mixed
     */
    public function getAdmissionType()
    {
        return $this->admissionType;
    }

    /**
     * @param mixed $admissionType
     */
    public function setAdmissionType($admissionType)
    {
        $this->admissionType = $admissionType;
    }

    /**
     * @return mixed
     */
    public function getAdmissionFees()
    {
        return $this->admissionFees;
    }

    /**
     * @param mixed $admissionFees
     */
    public function setAdmissionFees($admissionFees)
    {
        $this->admissionFees = $admissionFees;
    }

    /**
     * @return mixed
     */
    public function getHallAccomodation()
    {
        return $this->hallAccomodation;
    }

    /**
     * @param mixed $hallAccomodation
     */
    public function setHallAccomodation($hallAccomodation)
    {
        $this->hallAccomodation = $hallAccomodation;
    }

    /**
     * @return mixed
     */
    public function getLetterPrinted()
    {
        return $this->letterPrinted;
    }

    /**
     * @param mixed $letterPrinted
     */
    public function setLetterPrinted($letterPrinted)
    {
        $this->letterPrinted = $letterPrinted;
    }

    /**
     * @return mixed
     */
    public function getSmsSent()
    {
        return $this->sms_sent;
    }

    /**
     * @param mixed $sms_sent
     */
    public function setSmsSent($sms_sent)
    {
        $this->sms_sent = $sms_sent;
    }

    /**
     * @return mixed
     */
    public function getFormCompleted()
    {
        return $this->formCompleted;
    }

    /**
     * @param mixed $formCompleted
     */
    public function setFormCompleted($formCompleted)
    {
        $this->formCompleted = $formCompleted;
    }

    /**
     * @return mixed
     */
    public function getEligible()
    {
        return $this->eligible;
    }

    /**
     * @param mixed $eligible
     */
    public function setEligible($eligible)
    {
        $this->eligible = $eligible;
    }



    /**

     *
     * @ORM\Id
     * @ORM\GeneratedValue
     * @ORM\Column(type="integer")
     */
    private $id;

    /**

     *
     * @ORM\Column(type="string")
     */
    private $pin;
    /**

     * @Assert\NotBlank()
     * @ORM\Column(type="string",unique=true)
     */
    private $applicationNumber;

    /**
     * @return mixed
     */
    public function getFormId()
    {
        return $this->form_id;
    }

    /**
     * @param mixed $form_id
     */
    public function setFormId($form_id): void
    {
        $this->form_id = $form_id;
    }
    /**

     * @Assert\NotBlank()
     * @ORM\Column(type="string")
     */
    private $firstName;

    /**

     * @ORM\Column(type="string")
     */
    private $otherNames;


    /**

     * @ORM\Column(type="string",nullable=true)
     */
    private $form_id;



    /**

     * @Assert\NotBlank()
     * @ORM\Column(type="string")
     */
    private $lastName;

    /**

     * @Assert\NotBlank()
     * @ORM\Column(type="string")
     */
    private $title;

    /**

     * @Assert\NotBlank()
     * @ORM\Column(type="string")
     */
    private $name;

    /**

     * @Assert\NotBlank()
     * @ORM\Column(type="string")
     */
    private $gender;

    /**

     * @Assert\NotBlank()
     * @ORM\Column(type="string")
     */
    private $dob;

    /**

     * @Assert\NotBlank()
     * @ORM\Column(type="integer")
     */
    private $age;

    /**

     * @Assert\NotBlank()
     * @ORM\Column(type="string")
     */
    private $religion;

    /**
     * @return mixed
     */
    public function getReferrals()
    {
        return $this->referrals;
    }

    /**
     * @param mixed $referrals
     */
    public function setReferrals($referrals)
    {
        $this->referrals = $referrals;
    }

    /**

     * @Assert\NotBlank()
     * @ORM\Column(type="string",name="referrals",nullable=True)
     */
    private $referrals;




    /**

     * @ORM\Column(type="string",nullable=True)
     * @Assert\Blank()
     */
    private $denomination;

    /**
     * @Assert\Length(
     *      min = 10,
     *      max = 13,
     *      minMessage = "Your phone must be at least {{ limit }} characters long",
     *      maxMessage = "Your phone name cannot be longer than {{ limit }} characters"
     * )
     * @Assert\NotBlank()
     * @ORM\Column(type="string")
     */
    private $phone;

    /**

     * @Assert\NotBlank()
     * @ORM\Column(type="string")
     */
    private $maritalStatus;


    /**

     * @Assert\NotBlank()
     * @ORM\Column(type="string")
     */
    /**
     *
     * @ORM\ManyToOne(targetEntity="App\Entity\Country", cascade={"persist"} )
     * @ORM\JoinTable(name="admissions_applicants")
     * @ORM\OrderBy({"name": "ASC"})
     */


    private $nationality;



    /**
     * @Assert\Email(
     *     message = "The email '{{ value }}' is not a valid email.",

     * )

     * @ORM\Column(type="string")
     */
    private $email;

    /**

     * @Assert\NotBlank()
     * @ORM\Column(type="string")
     */
    private $address;

    /**

     * @ORM\Column(type="string" )
     */
    private $physicallyDisabled;

    /**

     * @ORM\Column(type="string",nullable=True)
     */
    private $disabilty;

    /**


     * @ORM\Column(name="admitted_by_id",type="string",nullable=True)
     */
    private $admittedBy;

    /**

     * @Assert\NotBlank()
     * @ORM\Column(type="string")
     */
    private $guardianName;

    /**
     * @Assert\Length(
     *      min = 10,
     *      max = 13,
     *      minMessage = "Your phone must be at least {{ limit }} characters long",
     *      maxMessage = "Your phone name cannot be longer than {{ limit }} characters"
     * )
     * @Assert\NotBlank()
     * @ORM\Column(type="string")
     */
    private $guardianPhone;

    /**

     * @Assert\NotBlank()
     * @ORM\Column(type="string")
     */
    private $guardianAddress;

    /**

     * @Assert\NotBlank()
     * @ORM\Column(type="string")
     */
    private $guardianOccupation;

    /**

     * @Assert\NotBlank()
     * @ORM\Column(type="string")
     */
    private $guardianRelationship;

    /**

     * @Assert\NotBlank()
     * @ORM\Column(type="string")
     */
    private $financeSource;
    // Academic portions

    /**
     *
     * @ORM\ManyToOne(targetEntity="App\Entity\School", cascade={"persist"} )
     * @ORM\JoinTable(name="admissions_applicants")
     * @ORM\OrderBy({"name": "ASC"})
     */
    private $formerSchool;

    /**

     * @Assert\NotBlank()
     * @ORM\Column(type="string")
     */

    private $hometown;


    /**
     *
     * @ORM\ManyToOne(targetEntity="App\Entity\Region", cascade={"persist"} )
     * @ORM\JoinTable(name="admissions_applicants")
     * @ORM\OrderBy({"name": "ASC"})
     */
    private $region;





    /**

     * @Assert\NotBlank()
     * @ORM\Column(type="string",nullable=True)
     */
    private $programmeStudied;



    /**
     *
     * @ORM\ManyToOne(targetEntity="App\Entity\Programme", cascade={"persist"} )
     * @ORM\JoinTable(name="admissions_applicants")
     * @ORM\OrderBy({"name": "ASC"})
     */

    private $programmeID1;

    /**
     * @return mixed
     */
    public function getProgrammeID1()
    {
        return $this->programmeID1;
    }

    /**
     * @param mixed $programmeID1
     */
    public function setProgrammeID1(Programme $programmeID1)
    {
        $this->programmeID1 = $programmeID1;
    }

    /**
     * @return mixed
     */
    public function getProgrammeID2()
    {
        return $this->programmeID2;
    }

    /**
     * @param mixed $programmeID2
     */
    public function setProgrammeID2(Programme $programmeID2)
    {
        $this->programmeID2 = $programmeID2;
    }

    /**
     * @return mixed
     */
    public function getProgrammeID3()
    {
        return $this->programmeID3;
    }

    /**
     * @param mixed $programmeID3
     */
    public function setProgrammeID3(Programme $programmeID3)
    {
        $this->programmeID3 = $programmeID3;
    }

    /**
     *
     * @ORM\ManyToOne(targetEntity="App\Entity\Programme", cascade={"persist"} )
     * @ORM\JoinTable(name="admissions_applicants")
     * @ORM\OrderBy({"name": "ASC"})
     */
    private $programmeID2;

    /**
     *
     * @ORM\ManyToOne(targetEntity="App\Entity\Programme", cascade={"persist"} )
     * @ORM\JoinTable(name="admissions_applicants")
     * @ORM\OrderBy({"name": "ASC"})
     */
    private $programmeID3;

    /**

     * @ORM\Column(type="string",nullable=True)
     */
    private $award;

    /**
     * @return mixed
     */
    public function getAwaiting()
    {
        return $this->awaiting;
    }

    /**
     * @param mixed $awaiting
     */
    public function setAwaiting($awaiting): void
    {
        $this->awaiting = $awaiting;
    }


    /**

     * @Assert\NotBlank()
     * @ORM\Column(type="string")
     */
    private $entryMode;

    /**

     * @Assert\NotBlank()
     * @ORM\Column(type="string")
     */
    private $formType;

    /**

     * @ORM\Column(type="string")
     */
    private $awaiting;



    /**

     * @ORM\Column(type="string",nullable=True)
     */
    private $preferedHall;

    /**

     * @ORM\Column(type="string" ,nullable=True)
     */
    private $yearOfAdmission;

    /**

     * @Assert\NotBlank()
     * @ORM\Column(type="string",nullable=True)
     */
    private $entryQualificationOne;

    /**

     * @ORM\Column(type="string",nullable=True)
     */
    private $entryQualificationTwo;

    /**

     * @Assert\Type(type = "numeric")
     * @Assert\NotBlank(
     *   message = "Grade should be a number"
     * )
     * @ORM\Column(type="string",nullable=True)
     */
    private $grade;

    /**

     * @ORM\Column(type="string",nullable=True)
     */
    private $bond;

    // Admission office actions

    /**

     * @ORM\Column(type="string",options={"default"=0},nullable=True)
     */
    private $qualify;

    /**

     * @ORM\Column(type="string",nullable=True)
     */
    private $results;
    /**

     * @Assert\NotBlank()
     * @ORM\Column(type="string", options={"default" ="Applicant" },nullable=True)
     */
    private $status;
    /**

     * @ORM\Column(type="integer",nullable=True)
     */
    private $admited;



    /**

     * @Assert\NotBlank()
     * @ORM\Column(name="programme_admitted_id",type="string",nullable=True)
     */
    private $programmeAdmitted;

    /**

     * @ORM\Column(name="hall_admitted_id",type="string",nullable=True)
     */
    private $hallAdmitted;

    /**

     * @ORM\Column(type="datetime",nullable=True)
     */
    private $dateAdmitted;

    /**

     * @Assert\NotBlank()
     * @ORM\Column(type="string", options={"default" ="Regular" },nullable=True)
     */
    private $sectionAdmitted;

    /**

     * @Assert\NotBlank()
     * @ORM\Column(type="string",nullable=True)
     */
    private $admissionType;


    /**

     * @Assert\NotBlank()
     * @ORM\Column(type="decimal" , nullable=True)
     */
    private $admissionFees;

    /**

     * @ORM\Column(type="boolean" ,nullable=True)
     */
    private $hallAccomodation;


    /**

     * @ORM\Column(type="integer",nullable=True)
     */
    private $letterPrinted;


    /**

     * @ORM\Column(type="boolean" ,nullable=True )
     */
    private $sms_sent;

    /**

     * @ORM\Column(type="boolean",nullable=True )
     */
    private $formCompleted;


    /**

     * @ORM\Column(type="string",nullable=True)
     */
    private $eligible;


    /**
     * @var datetime $created
     * @ORM\Column(type="datetime",nullable=True)
     */
    private $createdAt;

    /**

     * @var datetime $updated
     * @ORM\Column(type="datetime",nullable=True)
     */
    private $updatedAt;

    /**
     * Gets triggered only on insert

     * @ORM\PrePersist
     */
    public function onPrePersist()
    {
        $this->created = new \DateTime("now");
    }

    /**
     * Gets triggered every time on update

     * @ORM\PreUpdate
     */
    public function onPreUpdate()
    {
        $this->updated = new \DateTime("now");
    }

    public function setRegion(Region $regions): void
    {

            $this->region=$regions;

    }



    public function getRegion()
    {
        return $this->region;
    }


    /**
     * {@inheritdoc}
     */
    public function serialize(): string
    {
        return serialize([
            $this->id,
            $this->getName(),
            $this->applicationNumber,
            // see section on salt below
            // $this->salt,
        ]);
    }

    /**
     * {@inheritdoc}
     */
    public function unserialize($serialized): void
    {
        list(
            $this->id,
            $this->username,
            $this->password,
            // see section on salt below
            // $this->salt
            ) = unserialize($serialized);
    }
}
