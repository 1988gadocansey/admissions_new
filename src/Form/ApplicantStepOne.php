<?php
/*
 * This file is part of the Admission Software package.
 *
 * (c) Gad Ocansey <gadocansey@gmail.com>
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 */

namespace App\Form;

use App\Entity\Country;
use App\Entity\Region;
use Symfony\Component\Validator\Constraints;
use Doctrine\ORM\Mapping\Entity;
use Doctrine\ORM\Query\Expr\Select;
use Symfony\Bridge\Doctrine\Form\Type\EntityType;
use Symfony\Component\Form\Extension\Core\Type\EmailType;
use Symfony\Component\Form\Extension\Core\Type\NumberType;
use Symfony\Component\Form\Extension\Core\Type\DateType;
use Symfony\Component\Form\Extension\Core\Type\TelType;
use Symfony\Component\Form\Extension\Core\Type\TextType;
use Symfony\Component\Form\Extension\Core\Type\BirthdayType;
use Symfony\Component\Form\Extension\Core\Type\ChoiceType;
use Symfony\Component\Form\Extension\Core\Type\SubmitType;
use Symfony\Component\Form\AbstractType;
use Symfony\Component\Form\FormBuilderInterface;
use App\Entity\Applicant;
use Symfony\Component\OptionsResolver\OptionsResolver;
use Symfony\Component\Validator\Constraints\Choice;

use Doctrine\ORM\EntityManager;
use Doctrine\ORM\EntityManagerInterface;
use App\Repository\CountryRepository;
use App\Repository\ProgrammeRepository;


class ApplicantStepOne extends AbstractType
{
    private $em;
    private $existingApplicant;

    public function __construct(EntityManagerInterface $em)
    {
        $this->em = $em;

    }

    public function buildForm(FormBuilderInterface $builder, array $options)
    {
        // dump($options);die();
        $this->existingApplicant = $this->em->getRepository('App:Applicant')->findOneByApplicationNumber($options['user']);
        if (!empty($this->existingApplicant)) {
            $builder
                ->add('firstName', TextType::class, array(
                    'data' => @$this->existingApplicant->getFirstName(), 'required' => true


                , 'attr' => array('v-model' => 'applicant_step_one[firstName]', 'v-form-ctrl' => '', 'required' => '', 'id' => 'applicant_step_one[firstName]')

                ))
                ->add('lastName', TextType::class, array('data' => @$this->existingApplicant->getLastName(), 'attr' => array('v-model' => 'lastName', 'v-form-ctrl' => '', 'required' => '', 'id' => 'lastName')))
               
                ->add('otherNames', TextType::class,
                    array('required' => false, 'data' => @$this->existingApplicant->getOthernames(),'attr' => array('id' => 'othernames', 'v-form-ctrl' => ''))


                )
               

                ->add('title', ChoiceType::class, array('data' => @$this->existingApplicant->getTitle(), 'placeholder' => 'Choose an answer',
                    'choices' => array('Mr' => 'Mr', 'Mrs' => 'Mrs', 'Miss' => 'Miss', 'Rev' => 'Rev', 'Dr' => 'Dr', 'PhD' => 'PhD'),

                    'attr' => array('v-model' => 'title', 'v-select' => 'title', 'required' => '', 'id' => 'gender', 'class' => 'form-control select ui fluid search dropdown')
                ))
                ->add('gender', ChoiceType::class, array('data' => @$this->existingApplicant->getGender(), 'placeholder' => 'Choose an answer',
                    'choices' => array('Male' => 'Male', 'Female' => 'Female'),

                    'attr' => array('v-model' => 'gender', 'v-select' => 'gender', 'required' => '', 'id' => 'gender', 'class' => 'ui fluid search dropdown')
                ))
                ->add('maritalStatus', ChoiceType::class, array('data' => @$this->existingApplicant->getMaritalStatus(), 'placeholder' => 'Choose an answer',
                    'choices' => array('Married' => 'Married', 'Single' => 'Single'),

                    'attr' => array('v-model' => 'marital', 'v-select' => 'marital', 'required' => '', 'id' => 'marital', 'class' => 'ui fluid search dropdown')
                ))

                ->add('dob',  TextType::class, array('data' => @$this->existingApplicant->getDob(),  'label'=>'Date of Birth', 'attr' => array('v-model' => 'dob', 'v-form-ctrl' => '', 'required' => '', 'id' => 'dob','class'=>'dob')))


                ->add('phone', TextType::class, array('required' => true, 'data' => @$this->existingApplicant->getPhone(),))

                ->add('entryQualificationOne', ChoiceType::class, array('data' => @$this->existingApplicant->getentryQualificationOne(), 'placeholder' => 'Choose an answer',
                    'choices' => array('required' => true,'WASSSCE' => 'WASSSCE', 'SSSCE' => 'SSSCE', 'TEU/TECHNICAL CERTIFICATES' => 'TEU/TECHNICAL CERTIFICATES', 'NVTI' => 'NVTI', '1st Degree' => '1st Degree', '2nd Degree' => '2nd Degree', 'HND' => 'HND','NECO'=>'NECO'),

                    'attr' => array('v-model' => 'qualification1', 'v-select' => 'qualification1', 'required' => '', 'id' => 'qualification1', 'class' => 'ui fluid search dropdown')))


                ->add('entryQualificationTwo', ChoiceType::class, array('data' => @$this->existingApplicant->getentryQualificationOne(), 'placeholder' => 'Choose an answer',
                    'choices' => array( 'WASSSCE' => 'WASSSCE', 'SSSCE' => 'SSSCE', 'TEU/TECHNICAL CERTIFICATES' => 'TEU/TECHNICAL CERTIFICATES', 'NVTI' => 'NVTI', '1st Degree' => '1st Degree', '2nd Degree' => '2nd Degree', 'HND' => 'HND','NECO'=>'NECO','DIPLOMA'=>'DIPLOMA'),
                    'required'=>"false",

                    'attr' => array('v-model' => 'qualification2', 'v-select' => 'qualification2', 'id' => 'qualification2', 'class' => 'ui fluid search dropdown')))

                ->add('physicallyDisabled', ChoiceType::class, array('data' => @$this->existingApplicant->getPhysicallyDisabled(), 'placeholder' => 'Choose an answer',
                    'choices' => array('Yes' => 'Yes', 'No' => 'No'),

                    'attr' => array('v-model' => 'disability', 'v-select' => 'disability', 'required' => '', 'id' => 'disability', 'class' => 'ui fluid search dropdown')
                ))
                ->add('hometown', TextType::class, array('data' => @$this->existingApplicant->getHometown(), 'required' => true, 'attr' => array('v-model' => 'hometown', 'v-form-ctrl' => '', 'required' => '', 'id' => 'hometown')))
                ->add('address', TextType::class, array('data' => @$this->existingApplicant->getAddress(), 'required' => true, 'attr' => array('v-model' => 'address', 'v-form-ctrl' => '', 'required' => '', 'id' => 'address')))
                ->add('religion', TextType::class, array('data' => @$this->existingApplicant->getReligion(), 'label' => 'Religious denomination', 'required' => true, 'attr' => array('v-model' => 'religion', 'v-form-ctrl' => '', 'required' => '', 'id' => 'religion')))
                ->add('email', EmailType::class, array('data' => @$this->existingApplicant->getEmail(), 'required' => true, 'attr' => array('v-model' => 'email', 'v-form-ctrl' => '', 'id' => 'email')))
                ->add('bond', ChoiceType::class, array('data' => @$this->existingApplicant->getBond(), 'placeholder' => 'Choose your answer','label'=>'Are you bonded to any organization?',
                    'choices' => array('Not bonded' => 'No', 'Bonded' => 'Yes'), 'required' => true,

                    'attr' => array('v-model' => 'bond', 'v-select' => 'bond', 'required' => '', 'id' => 'bond', 'class' => 'ui fluid search dropdown')

                ))
                ->add('region', EntityType::class, [
                    'data' => @$this->existingApplicant->getRegion(),
                    'class' => Region::class,
                    'label'=>"Current location region",
                    'required' => true,
                    'placeholder' => 'Choose location region',
                    'attr' => ['v-model' => 'region', 'v-select' => 'region', 'required' => '', 'id' => 'region', 'class' => 'ui fluid search dropdown']


                ])

                ->add('guardianName', TextType::class, array('data' => @$this->existingApplicant->getGuardianName(), 'required' => true, 'attr' => array('v-model' => 'guardianName', 'v-form-ctrl' => '', 'required' => '', 'id' => 'guardianName')))
                ->add('guardianAddress', TextType::class, array('data' => @$this->existingApplicant->getGuardianAddress(), 'required' => true, 'attr' => array('v-model' => 'guardianAddress', 'v-form-ctrl' => '', 'required' => '', 'id' => 'lastName', 'class' => 'guardianAddress')))
                ->add('financeSource', TextType::class, array('data' => @$this->existingApplicant->getfinanceSource(), 'required' => true, 'attr' => array('v-model' => 'financeSource', 'v-form-ctrl' => '', 'required' => '', 'id' => 'financeSource', 'class' => 'financeSource')))
                ->add('guardianOccupation', TextType::class, array('data' => @$this->existingApplicant->getGuardianOccupation(), 'required' => true, 'attr' => array('id' => 'guardianOccupation', 'v-form-ctrl' => '')))
                ->add('guardianRelationship', TextType::class, array('data' => @$this->existingApplicant->getGuardianRelationship(), 'attr' => array('class' => 'form-control', 'v-form-ctrl' => '')))
                ->add('guardianPhone', TextType::class, array('data' => @$this->existingApplicant->getGuardianPhone(),'attr' => array('id' => 'guardianPhone', 'v-form-ctrl' => '')))
                ->add('Save', SubmitType::class, array('attr' => array('class' => 'btn primary ', 'v-form-ctrl' => '')));

            if ($options['type']=="FOREIGN") {

                $builder->add('nationality', EntityType::class, [
                    'data' => @$this->existingApplicant->getNationality(),
                    'class' => Country::class,'query_builder' => function(CountryRepository $repo) {
                        return $repo->createAlphabeticalQueryBuilder();
                    },
                    'required' => true,

                    'label' => 'Country',
                    'placeholder' => 'Choose your country of origin',
                    'attr' => ['v-model' => 'country', 'v-select' => 'country', 'required' => '', 'id' => 'country', 'class' => 'ui fluid search dropdown']


                ]);
            }





        } else {
            $builder
                ->add('firstName', TextType::class, array(
                     'required' => true


                , 'attr' => array('v-model' => 'applicant_step_one[firstName]', 'v-form-ctrl' => '', 'required' => '', 'id' => 'applicant_step_one[firstName]')

                ))
                ->add('lastName', TextType::class, array(  'attr' => array('v-model' => 'lastName', 'v-form-ctrl' => '', 'required' => '', 'id' => 'lastName')))
                ->add('otherNames', TextType::class, array('required'=>false, 'attr' => array('id' => 'othernames', 'v-form-ctrl' => '')))
                ->add('title', ChoiceType::class, array( 'placeholder' => 'Choose an answer',
                    'choices' => array('Mr' => 'Mr', 'Mrs' => 'Mrs', 'Miss' => 'Miss', 'Rev' => 'Rev', 'Dr' => 'Dr', 'PhD' => 'PhD'),

                    'attr' => array('v-model' => 'title', 'v-select' => 'title', 'required' => '', 'id' => 'gender', 'class' => 'select select-wrapper form-control search dropdown')
                ))
                ->add('gender', ChoiceType::class, array( 'placeholder' => 'Choose an answer',
                    'choices' => array('Male' => 'Male', 'Female' => 'Female'),

                    'attr' => array('v-model' => 'gender', 'v-select' => 'gender', 'required' => '', 'id' => 'gender', 'class' => 'select select-wrapper ui fluid search dropdown')
                ))
                ->add('maritalStatus', ChoiceType::class, array( 'placeholder' => 'Choose an answer',
                    'choices' => array('Married' => 'Married', 'Single' => 'Single'),

                    'attr' => array('v-model' => 'marital', 'v-select' => 'marital', 'required' => '', 'id' => 'marital', 'class' => 'ui fluid search dropdown')
                ))

                ->add('dob', TextType::class, array(  'attr' => array('v-model' => 'dob', 'v-form-ctrl' => '', 'required' => '', 'id' => 'dob','class'=>'dob'), 'label'=>'Date of Birth'))

                ->add('phone', TextType::class, array('required' => true,  ))
                ->add('entryQualificationOne', ChoiceType::class, array(  'placeholder' => 'Choose an answer',
                    'choices' => array('WASSSCE' => 'WASSSCE', 'SSSCE' => 'SSSCE', 'TEU/TECHNICAL CERTIFICATES' => 'TEU/TECHNICAL CERTIFICATES', 'NVTI' => 'NVTI', '1st Degree' => '1st Degree', 'HND' => 'HND', 'DIPLOMA'=>'DIPLOMA','NECO'=>'NECO','Other' => 'Other'),

                    'attr' => array('v-model' => 'qualification1', 'v-select' => 'qualification1', 'required' => '', 'id' => 'qualification1', 'class' => 'ui fluid search dropdown')))





                ->add('entryQualificationTwo', ChoiceType::class, [
                    'required' => false,

                    'choices' => [
                        '' => 'select second qualification if available',
                        'WASSSCE' => 'WASSSCE',
                        'SSSCE' => 'SSSCE',
                        'TEU/TECHNICAL CERTIFICATES' => 'TEU/TECHNICAL CERTIFICATES',
                        'NVTI' => 'NVTI', '1st Degree' => '1st Degree', 'HND' => 'HND','NECO'=>'NECO', 'Other' => 'Other'

                    ],
                    'attr'=>['v-model' => 'qualification2', 'v-select' => 'qualification1', 'id' => 'qualification2', 'class' => 'ui fluid search dropdown']
                ])




                ->add('physicallyDisabled', ChoiceType::class, array( 'placeholder' => 'Choose an answer',
                    'choices' => array('Yes' => 'Yes', 'No' => 'No'),

                    'attr' => array('v-model' => 'disability', 'v-select' => 'disability', 'required' => '', 'id' => 'disability', 'class' => 'ui fluid search dropdown')
                ))
                ->add('hometown', TextType::class, array(   'required' => true, 'attr' => array('v-model' => 'hometown', 'v-form-ctrl' => '', 'required' => '', 'id' => 'hometown')))
                ->add('address', TextType::class, array(  'required' => true, 'attr' => array('v-model' => 'address', 'v-form-ctrl' => '', 'required' => '', 'id' => 'address')))
                ->add('religion', TextType::class, array(  'label' => 'Religious denomination', 'required' => true, 'attr' => array('v-model' => 'religion', 'v-form-ctrl' => '', 'required' => '', 'id' => 'religion')))
                ->add('email', EmailType::class, array(  'required' => true, 'attr' => array('v-model' => 'email', 'v-form-ctrl' => '', 'id' => 'email')))
                ->add('bond', ChoiceType::class, array(  'placeholder' => 'Choose your answer','label'=>'Are you bonded to any organization?',
                    'choices' => array('Not bonded' => 'No', 'Bonded' => 'Yes'), 'required' => true,'label'=>'Are you bonded to any organization?',

                    'attr' => array('v-model' => 'bond', 'v-select' => 'bond', 'required' => '', 'id' => 'bond', 'class' => 'ui fluid search dropdown')

                ))
                ->add('region', EntityType::class, [

                    'class' => Region::class,
                    'label'=>"Current location region",
                    'placeholder' => 'Choose location region',
                    'attr' => ['v-model' => 'region', 'v-select' => 'region', 'required' => '', 'id' => 'region', 'class' => 'ui fluid select search dropdown']


                ])

                ->add('guardianName', TextType::class, array( 'required' => true, 'attr' => array('v-model' => 'guardianName', 'v-form-ctrl' => '', 'required' => '', 'id' => 'guardianName')))
                ->add('guardianAddress', TextType::class, array( 'required' => true, 'attr' => array('v-model' => 'guardianAddress', 'v-form-ctrl' => '', 'required' => '', 'id' => 'lastName', 'class' => 'guardianAddress')))
                ->add('financeSource', TextType::class, array( 'required' => true, 'attr' => array('v-model' => 'financeSource', 'v-form-ctrl' => '', 'required' => '', 'id' => 'financeSource', 'class' => 'financeSource')))
                ->add('guardianOccupation', TextType::class, array(  'required' => true, 'attr' => array('id' => 'guardianOccupation', 'v-form-ctrl' => '')))
                ->add('guardianRelationship', TextType::class, array(  'attr' => array('id' => 'guardianRelationship', 'v-form-ctrl' => '')))
                ->add('guardianPhone', TextType::class, array( 'required' => true))
                ->add('Save', SubmitType::class, array('attr' => array('class' => 'btn primary', 'v-form-ctrl' => '')));

            if ($options['type']=="FOREIGN") {
                $builder->
                add('nationality', EntityType::class, [

                    'class' => Country::class,
                    'query_builder' => function(CountryRepository $repo) {
                        return $repo->createAlphabeticalQueryBuilder();
                    },
                    'required' => true,

                    'label' => 'Country',
                    'placeholder' => 'Choose your country of origin',
                    'attr' => ['v-model' => 'country', 'v-select' => 'country', 'required' => '', 'id' => 'country', 'class' => 'ui fluid search dropdown']


                ]);
            }
        }
    }

    /**
     * @param OptionsResolverInterface $resolver
     */
    public function configureOptions(OptionsResolver $resolver)
    {
        $resolver->setDefaults(array(
            'data_class' => Applicant::class,
            'attr' => array('class' => 'validated'),
            'novalidate' => 'novalidate',

        ));

        $resolver->setRequired('user');
        $resolver->setRequired('type');


    }


}