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
use Doctrine\Common\Collections\Collection;
use Doctrine\ORM\Mapping as ORM;

/**
 * @ORM\Entity()
 * @ORM\Table(name="admissions_faculties")
 *
 * Defines the properties of the Region entity to represent the applicant region.
 * @author Gad Ocansey <gadocansey@gmail.com>
 */
class Faculty
{
    /**
     * @var int
     *
     * @ORM\Id
     * @ORM\GeneratedValue
     * @ORM\Column(name="faculty_id",type="integer")
     */
    private $faculty_id;



    /**
     * @var string
     *
     * @ORM\Column(name="faculty_name",type="string", unique=true)
     */
    private $faculty_name;

    /**
     * @var string
     *
     * @ORM\Column(name="faculty_code",type="string", unique=true)
     */
    private $faculty_code;

    /**
     * @var ArrayCollection
     * @ORM\OneToMany(targetEntity="App\Entity\Department",mappedBy="faculty_id_id")
     */
    private $department;

    public function __construct()
    {
        $this->department=new ArrayCollection();
    }

    public function getFacultyId(): ?int
    {
        return $this->faculty_id;
    }

    public function getFacultyName(): ?string
    {
        return $this->faculty_name;
    }

    public function setFacultyName(string $faculty_name): self
    {
        $this->faculty_name = $faculty_name;

        return $this;
    }

    public function getFacultyCode(): ?string
    {
        return $this->faculty_code;
    }

    public function setFacultyCode(string $faculty_code): self
    {
        $this->faculty_code = $faculty_code;

        return $this;
    }

    /**
     * @return Collection|Department[]
     */
    public function getDepartment(): Collection
    {
        return $this->department;
    }

    public function addDepartment(Department $department): self
    {
        if (!$this->department->contains($department)) {
            $this->department[] = $department;
            $department->setFacultyIdId($this);
        }

        return $this;
    }

    public function removeDepartment(Department $department): self
    {
        if ($this->department->contains($department)) {
            $this->department->removeElement($department);
            // set the owning side to null (unless already changed)
            if ($department->getFacultyIdId() === $this) {
                $department->setFacultyIdId(null);
            }
        }

        return $this;
    }



}
