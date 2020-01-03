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
 * @ORM\Table(name="admissions_banks")
 *
 * Defines the properties of the Region entity to represent the applicant region.
 * @author Gad Ocansey <gadocansey@gmail.com>
 */
class Bank
{
    /**
     * @var int
     *
     * @ORM\Id
     * @ORM\GeneratedValue
     * @ORM\Column(type="integer")
     */
    private $bank_id;

    /**
     * @return int
     */
    public function getBankId()
    {
        return $this->bank_id;
    }

    /**
     * @param int $bank_id
     */
    public function setBankId($bank_id)
    {
        $this->bank_id = $bank_id;
    }

    /**
     * @return string
     */
    public function getBankName()
    {
        return $this->bank_name;
    }

    /**
     * @param string $bank_name
     */
    public function setBankName($bank_name)
    {
        $this->bank_name = $bank_name;
    }

    /**
     * @return string
     */
    public function getBankAccountNumber()
    {
        return $this->bank_account_number;
    }

    /**
     * @param string $bank_account_number
     */
    public function setBankAccountNumber($bank_account_number)
    {
        $this->bank_account_number = $bank_account_number;
    }



    /**
     * @var string
     *
     * @ORM\Column(type="string", unique=true)
     */
    private $bank_name;

    /**
     * @var string
     *
     * @ORM\Column(type="string", unique=true)
     */
    private $bank_account_number;


    /**
     *
     * @ORM\OneToMany(targetEntity="App\Entity\Hall",mappedBy="hall_bank_id" )
     * @ORM\JoinTable(name="admissions_banks")
     */
    private $hall;

    public function __construct()
    {
        $this->hall = new ArrayCollection();
    }

    /**
     * @return Collection|Hall[]
     */
    public function getHall(): Collection
    {
        return $this->hall;
    }

    public function addHall(Hall $hall): self
    {
        if (!$this->hall->contains($hall)) {
            $this->hall[] = $hall;
            $hall->setHallBankId($this);
        }

        return $this;
    }

    public function removeHall(Hall $hall): self
    {
        if ($this->hall->contains($hall)) {
            $this->hall->removeElement($hall);
            // set the owning side to null (unless already changed)
            if ($hall->getHallBankId() === $this) {
                $hall->setHallBankId(null);
            }
        }

        return $this;
    }

}
