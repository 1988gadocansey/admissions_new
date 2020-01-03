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

use App\Entity\ExamResult;
use App\Entity\Subject;
use App\Entity\Region;
use App\Entity\School;
use App\Entity\WEACGrades;
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
use Doctrine\ORM\EntityManagerInterface;
use Symfony\Component\Form\Extension\Core\Type\RangeType;
class ApplicantStepThree extends AbstractType
{
    private $em;
    private $existingApplicant;

    public function __construct(EntityManagerInterface $em)
    {
        $this->em = $em;

    }
    public function buildForm(FormBuilderInterface $builder, array $options)
    {
        $this->existingApplicant = $this->em->getRepository('App:Applicant')->findOneByApplicationNumber($options['user']);

        $builder->add('subject', EntityType::class, [

                'class' => Subject::class,
                'required'=>true,
                'label'=>'Subject',
                'placeholder' => 'select',
                'attr'=> ['v-model'=>'subject','v-select'=>'subject', 'id'=>'subject','class'=>'ui fluid search dropdown']


            ])
            ->add('grade', EntityType::class, [

                'class' => WEACGrades::class,
                'required'=>true,
                'label'=>'Grade',
                'placeholder' => 'select',
                'attr'=> ['v-model'=>'grade','v-select'=>'grade', 'id'=>'grade','class'=>'ui fluid search dropdown']


            ])

            ->add('sitting', ChoiceType::class, array('required'=>true,  'placeholder' => 'select',
                'choices'   => array( '1st sitting' => '1', '2nd sitting' => '2','3rd sitting'=>'3' ),

                'attr'=>array('v-model'=>'sitting','v-select'=>'sitting','id'=>'sitting','class'=>'ui fluid search dropdown')))

            ->add('examType', ChoiceType::class, array('required'=>true,  'placeholder' => 'select',
                'choices'   => array(  'WASSSCE' => 'WASSSCE', 'SSSCE' => 'SSSCE',"NOV/DEC"=>"NOV/DEC",'NVTI'=>'NVTI' ,"ABCE"=>"ABCE","Diploma"=>"Diploma","NAPTEX"=>"NAPTEX","GCE A LEVEL"=>"GCE A LEVEL","G.E.S-TEU Certificate"=>"G.E.S-TEU Certificate","Other"=>"Other"),

                'attr'=>array('v-model'=>'examType','v-select'=>'examType','id'=>'examType','class'=>'ui fluid search dropdown')))


            ->add('indexNo', TextType::class, array(  'required' => true,'attr' => array( 'v-model'=>'indexno','v-form-ctrl'=>'','required'=>'','id'=>'indexno')))



            ->add('center', TextType::class, array('label'=>'Exam Center',  'required' => true,'attr' => array( 'v-model'=>'center','v-form-ctrl'=>'', 'id'=>'center')))



            ->add('month', ChoiceType::class, array('required'=>true,  'placeholder' => 'select',
                'choices'   => array( 'MAY/JUNE' => '6', "NOV/DEC"=>"12"), 'attr'=>array('v-model'=>'sitting','v-select'=>'sitting','id'=>'sitting','class'=>'ui fluid search dropdown'))
)

            ->add('year', ChoiceType::class,
                array(
                    'required' => true, 'choices' => $this->buildYearChoices(), 'attr'=>array('v-model'=>'sitting','v-select'=>'sitting','id'=>'sitting','class'=>'ui fluid search dropdown')
                ))


        ->add('Save and add new', SubmitType::class ,array('attr' => array( 'class'=>'ui large orange button ','v-form-ctrl'=>'')));
    }

    public function buildYearChoices() {
        $distance = 50;
        $yearsBefore = date('Y', mktime(0, 0, 0, date("m"), date("d"), date("Y") - $distance));
        $yearsAfter = date('Y', mktime(0, 0, 0, date("m"), date("d"), date("Y") ));
        return array_combine(range($yearsBefore, $yearsAfter), range($yearsBefore, $yearsAfter));
    }
    /**
     * @param OptionsResolverInterface $resolver
     */
    public function configureOptions(OptionsResolver $resolver)
    {
        $resolver->setDefaults(array(
            'data_class' => ExamResult::class,
            //'attr' => array('class' => 'ui loadable form')
            'attr' => array('class' => 'ui form')
        ));
        $resolver->setRequired('user');
    }


}