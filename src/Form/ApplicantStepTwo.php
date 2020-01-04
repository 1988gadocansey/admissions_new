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
use App\Entity\Programme;
use App\Entity\Region;
use App\Entity\School;
use App\Repository\ProgrammeRepository as prepo;
use Doctrine\ORM\Mapping\Entity;
use Doctrine\ORM\Query\Expr\Select;
use Symfony\Bridge\Doctrine\Form\Type\EntityType;
use Symfony\Component\Form\Extension\Core\Type\EmailType;
use Symfony\Component\Form\Extension\Core\Type\NumberType;
use Symfony\Component\Form\Extension\Core\Type\RadioType;
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
use libphonenumber\PhoneNumberFormat;
use Misd\PhoneNumberBundle\Form\Type\PhoneNumberType;
use Doctrine\ORM\EntityManagerInterface;

class ApplicantStepTwo extends AbstractType
{
    private $em;
    private $existingApplicant;
    private $type;
    public function __construct(EntityManagerInterface $em)
    {
        $this->em = $em;


    }
    public function buildForm(FormBuilderInterface $builder, array $options)
    {
        $type=$options['type'];
        $this->existingApplicant = $this->em->getRepository('App:Applicant')->findOneByApplicationNumber($options['user']);

        $builder

            ->add('programmeID1', EntityType::class, [
                'data' =>$this->existingApplicant->getProgrammeID1(),
                'class' => Programme::class,
                'query_builder' => function (prepo $repository) use($type)
                {
                    if($type=="FOREIGN") {
                        return $repository->createQueryBuilder('p')
                            ->where('p.running = ?1')
                            ->setParameter(1,    1)
                            ->add('orderBy', 'p.name ASC');
                    }
                    elseif ($type=="HND"){
                        $type="HND";
                        return $repository->createQueryBuilder('p')
                            ->where('p.running = ?1')
                            ->andWhere('p.type = ?2')
                            ->setParameter(1,    1)
                            ->setParameter(2,    $type)
                            ->add('orderBy', 'p.name ASC');
                    }
                    elseif ($type=="DIPLOMA"){
                        $type="NON-TERTIARY";
                        return $repository->createQueryBuilder('p')
                            ->where('p.running = ?1')
                            ->andWhere('p.type = ?2')
                            ->setParameter(1,    1)
                            ->setParameter(2,    $type)

                            ->add('orderBy', 'p.name ASC');
                    }
                    elseif ($type=="BTECH"){
                        $type="BTECH";
                        return $repository->createQueryBuilder('p')
                            ->where('p.running = ?1')
                            ->andWhere('p.type = ?2')
                            ->setParameter(1,    1)
                            ->setParameter(2,    $type)
                            ->add('orderBy', 'p.name ASC');
                    }
                    elseif ($type=="MATURE"){
                        $type="HND";
                        return $repository->createQueryBuilder('p')
                            ->where('p.running = ?1')
                            ->andWhere('p.type = ?2')
                            ->setParameter(1,    1)
                            ->setParameter(2,    $type)
                            ->add('orderBy', 'p.name ASC');
                    }
                    elseif ($type=="MTECH"){
                        $type="POSTGRADUATE";
                        return $repository->createQueryBuilder('p')
                            ->where('p.running = ?1')
                            ->andWhere('p.type = ?2')
                            ->setParameter(1,    1)
                            ->setParameter(2,    $type)
                            ->add('orderBy', 'p.name ASC');
                    }
                    else{
                        $type="HND";
                        return $repository->createQueryBuilder('p')
                            ->where('p.running = ?1')
                            ->andWhere('p.type = ?2')
                            ->setParameter(1,    1)
                            ->setParameter(2,    $type)
                            ->add('orderBy', 'p.name ASC');
                    }

                },
                'required'=>true,
                'label'=>'First Choice',
                'placeholder' => 'Choose your first choice',
                'attr'=> ['v-model'=>'firstChoice','v-select'=>'firstChoice', 'id'=>'firstChoice','class'=>'ui fluid search dropdown']


            ])
            ->add('programmeID2', EntityType::class, [
                'data' =>$this->existingApplicant->getProgrammeID2(),
                'class' => Programme::class,
                'query_builder' => function (prepo $repository) use($type)
                {
                    if($type=="FOREIGN") {
                        return $repository->createQueryBuilder('p')
                            ->where('p.running = ?1')
                            ->setParameter(1,    1)

                            ->add('orderBy', 'p.name ASC');
                    }
                    elseif ($type=="HND"){
                        $type="HND";
                        return $repository->createQueryBuilder('p')
                            ->where('p.running = ?1')
                            ->andWhere('p.type = ?2')
                            ->setParameter(1,    1)
                            ->setParameter(2,    $type)
                            ->add('orderBy', 'p.name ASC');
                    }
                    elseif ($type=="DIPLOMA"){
                        $type="NON-TERTIARY";
                        return $repository->createQueryBuilder('p')
                            ->where('p.running = ?1')
                            ->andWhere('p.type = ?2')
                            ->setParameter(1,    1)
                            ->setParameter(2,    $type)

                            ->add('orderBy', 'p.name ASC');
                    }
                    elseif ($type=="BTECH"){
                        $type="BTECH";
                        return $repository->createQueryBuilder('p')
                            ->where('p.running = ?1')
                            ->andWhere('p.type = ?2')
                            ->setParameter(1,    1)
                            ->setParameter(2,    $type)
                            ->add('orderBy', 'p.name ASC');
                    }
                    elseif ($type=="MATURE"){
                        $type="HND";
                        return $repository->createQueryBuilder('p')
                            ->where('p.running = ?1')
                            ->andWhere('p.type = ?2')
                            ->setParameter(1,    1)
                            ->setParameter(2,    $type)
                            ->add('orderBy', 'p.name ASC');
                    }
                    elseif ($type=="MTECH"){
                        $type="POSTGRADUATE";
                        return $repository->createQueryBuilder('p')
                            ->where('p.running = ?1')
                            ->andWhere('p.type = ?2')
                            ->setParameter(1,    1)
                            ->setParameter(2,    $type)
                            ->add('orderBy', 'p.name ASC');
                    }
                    else{
                        $type="HND";
                        return $repository->createQueryBuilder('p')
                            ->where('p.running = ?1')
                            ->andWhere('p.type = ?2')
                            ->setParameter(1,    1)
                            ->setParameter(2,    $type)
                            ->add('orderBy', 'p.name ASC');
                    }

                },
                'required'=>true,
                'label'=>'Second Choice',
                'placeholder' => 'Choose your second choice',
                'attr'=> ['v-model'=>'secondChoice','v-select'=>'secondChoice', 'id'=>'secondChoice','class'=>'ui fluid search dropdown']


            ])
            ->add('formerSchool', EntityType::class, [
                'data' =>$this->existingApplicant->getFormerSchool(),
                'class' => School::class,

                'required'=>true,
                'label'=>'Former School Attended',
                'placeholder' => 'Choose your school',
                'attr'=> ['v-model'=>'formerSchool','v-select'=>'formerSchool','required'=>'','id'=>'formerSchool','class'=>'ui fluid search dropdown']


            ])
            ->add('programmeID3', EntityType::class, [
                'data' =>$this->existingApplicant->getProgrammeID3(),
                'class' => Programme::class,
                'query_builder' => function (prepo $repository) use($type)
                {
                    if($type=="FOREIGN") {
                        return $repository->createQueryBuilder('p')
                            ->where('p.running = ?1')
                            ->setParameter(1,    1)

                            ->add('orderBy', 'p.name ASC');
                    }
                    elseif ($type=="HND"){
                        $type="HND";
                        return $repository->createQueryBuilder('p')
                            ->where('p.type = ?1')
                            ->andWhere('p.running = ?2')
                            ->setParameter(1,    $type)
                            ->setParameter(2,    1)
                            ->add('orderBy', 'p.name ASC');
                    }
                    elseif ($type=="DIPLOMA"){
                        $type="NON-TERTIARY";
                        return $repository->createQueryBuilder('p')
                            ->where('p.type = ?1')
                            ->andWhere('p.running = ?2')
                            ->setParameter(1,    $type)
                            ->setParameter(2,    1)
                            ->add('orderBy', 'p.name ASC');
                    }
                    elseif ($type=="BTECH"){
                        $type="BTECH";
                        return $repository->createQueryBuilder('p')
                            ->where('p.type = ?1')
                            ->andWhere('p.running = ?2')
                            ->setParameter(1,    $type)
                            ->setParameter(2,    1)
                            ->add('orderBy', 'p.name ASC');
                    }
                    elseif ($type=="MATURE"){
                        $type="HND";
                        return $repository->createQueryBuilder('p')
                            ->where('p.type = ?1')
                            ->andWhere('p.running = ?2')
                            ->setParameter(1,    $type)
                            ->setParameter(2,    1)
                            ->add('orderBy', 'p.name ASC');
                    }
                    elseif ($type=="MTECH"){
                        $type="POSTGRADUATE";
                        return $repository->createQueryBuilder('p')
                            ->where('p.type = ?1')
                            ->andWhere('p.running = ?2')
                            ->setParameter(1,    $type)
                            ->setParameter(2,    1)
                            ->add('orderBy', 'p.name ASC');
                    }

                },
                'required'=>true,
                'label'=>'Third Choice',
                'placeholder' => 'Choose your third choice',
                'attr'=> ['v-model'=>'thirdChoice','v-select'=>'thirdChoice','required'=>'','id'=>'thirdChoice','class'=>'ui fluid search dropdown']


            ])

            ->add('preferedHall', ChoiceType::class, array(

                'data' =>$this->existingApplicant->getPreferedHall(),
                'choices' => array(
                    'Male Halls' => array(
                        'Nzema Hall' => 'Nzema',
                        'Ahanta Hall' => 'Ahanta',
                    ),
                    'Female Halls' => array(
                        'Ghacem Hall' => 'Ghacem',

                    ),
                    'Mixed Sex Hall' => array(
                        'GetFund Hall' => 'GetFund',

                    )
                ),
                'attr'=>array('v-model'=>'hall','v-select'=>'hall','id'=>'hall','class'=>'ui fluid search dropdown')

            ))

            ->add('programmeStudied', TextType::class, array( 'required' => true, 'attr' => array('v-model' => 'guardianAddress', 'v-form-ctrl' => '', 'required' => '', 'id' => 'lastName')))


            ->add('referrals', ChoiceType::class, [
                'required' => true,
                'label' => 'How did you hear about the admissions ',
                'data' => @$this->existingApplicant->getReferrals(),
                'choices' => [
                    '' => 'select referral',
                    'TTU Outreach Team' => 'outreach', 'Print Media Advertisement' => 'advert', 'Social Media Platform' => 'social', 'Friends' => 'friend','Others' => 'other'
                ],
                'attr' => ['v-model' => 'referrals', 'v-select' => 'referrals', 'id' => 'referrals', 'class' => 'ui fluid search dropdown']
            ])


        ->add('awaiting', ChoiceType::class, [
        'required' => true,
        'label' => 'Apply as awaiting result? ',
        'data' => @$this->existingApplicant->getAwaiting(),
        'choices' => [
            '' => 'select answer',
            'Yes' => '1', 'No' => '0'
        ],
        'attr' => ['v-model' => 'awaiting', 'v-select' => 'awaiting', 'id' => 'awaiting', 'class' => 'ui fluid search dropdown']
    ]);




        if ($options['type']=="BTECH" || $options['type']=="MTECH" ) {

            $builder
                ->add('award', ChoiceType::class, [
                    'required' => false,
                    'label' => 'Class obtained ',
                    'data' => @$this->existingApplicant->getAward(),
                    'choices' => [
                        '' => 'select class',
                        'First Class' => '1st Class', 'Second Upper' => '2nd Upper', 'Second Lower' => '2nd Lower', 'Third Class' => '3rd Class'
                    ],
                    'attr' => ['v-model' => 'qualification2', 'v-select' => 'qualification1', 'id' => 'qualification2', 'class' => 'ui fluid search dropdown']
                ]);


        }

        $builder->add('Save', SubmitType::class ,array('attr' => array( 'class'=>'btn primary ','v-form-ctrl'=>'')));




    }
    /**
     * @param OptionsResolverInterface $resolver
     */
    public function configureOptions(OptionsResolver $resolver)
    {
        $resolver->setDefaults(array(
            'data_class' => Applicant::class,
            //'attr' => array('class' => 'ui loadable form')
            'attr' => array('class' => 'ui  validated')
        ));
        $resolver->setRequired('user');
        $resolver->setRequired('type');
    }


}