<?php

/*
 * This file is part of the Admission package.
 *
 * (c) Gad Ocansey <gadocansey@gmail.com.com>
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 */

namespace App\Entity;

use Doctrine\Common\Collections\ArrayCollection;
use Doctrine\ORM\Mapping as ORM;

/**
 * @ORM\Entity()
 * @ORM\Table(name="admissions_departments")
 * Defines the properties of the Region entity to represent the applicant region.
 * @author Gad Ocansey <gadocansey@gmail.com>
 */
class Department
{
    /**
     * @var int
     *
     * @ORM\Id
     * @ORM\GeneratedValue
     * @ORM\Column(name="department_id",type="integer")
     */
    private $department_id;



    /**
     * @var string
     *
     * @ORM\Column(name="department_name",type="string", unique=true)
     */
    private $department_name;

    /**
     * @var string
     *
     * @ORM\Column(name="department_code",type="string", unique=true)
     */
    private $department_code;

    /**
     * @return int
     */
    public function getDepartmentId()
    {
        return $this->department_id;
    }

    /**
     * @param int $department_id
     */
    public function setDepartmentId($department_id)
    {
        $this->department_id = $department_id;
    }

    /**
     * @return string
     */
    public function getDepartmentName()
    {
        return $this->department_name;
    }

    /**
     * @param string $department_name
     */
    public function setDepartmentName($department_name)
    {
        $this->department_name = $department_name;
    }

    /**
     * @return string
     */
    public function getDepartmentCode()
    {
        return $this->department_code;
    }

    /**
     * @param string $department_code
     */
    public function setDepartmentCode($department_code)
    {
        $this->department_code = $department_code;
    }

    /**
     * @return mixed
     */
    public function getFacultyIdId()
    {
        return $this->faculty_id_id;
    }

    /**
     * @param mixed $faculty_id_id
     */
    public function setFacultyIdId($faculty_id_id)
    {
        $this->faculty_id_id = $faculty_id_id;
    }


    /**
     *
     * @ORM\ManyToOne(targetEntity="App\Entity\Faculty", cascade={"persist"} )
     * @ORM\JoinTable(name="admissions_faculties")
     * @ORM\OrderBy({"faculty_name": "ASC"})
     * @ORM\JoinColumn(name="faculty_id_id", referencedColumnName="faculty_id")
     */
    private $faculty_id_id;
}
