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
 * @ORM\Table(name="admissions_halls")
 *
 * Defines the properties of the Hall entity to represent the applicant hall admitted to
 * @author Gad Ocansey <gadocansey@gmail.com>
 */
class Hall
{
    /**
     * @return int
     */
    public function getHallId()
    {
        return $this->hall_id;
    }

    /**
     * @param int $hall_id
     */
    public function setHallId($hall_id)
    {
        $this->hall_id = $hall_id;
    }

    /**
     * @return string
     */
    public function getHallName()
    {
        return $this->hall_name;
    }

    /**
     * @param string $hall_name
     */
    public function setHallName($hall_name)
    {
        $this->hall_name = $hall_name;
    }

    /**
     * @return mixed
     */
    public function getHallBankId()
    {
        return $this->hall_bank_id;
    }

    /**
     * @param mixed $hall_bank_id
     */
    public function setHallBankId($hall_bank_id)
    {
        $this->hall_bank_id = $hall_bank_id;
    }
    /**
     * @var int
     *
     * @ORM\Id
     * @ORM\GeneratedValue
     * @ORM\Column(name="hall_id",type="integer")
     */
    private $hall_id;



    /**
     * @var string
     *
     * @ORM\Column(type="string", unique=true)
     */
    private $hall_name;

    /**
     *
     * @ORM\ManyToOne(targetEntity="App\Entity\Bank", cascade={"persist"},inversedBy="hall" )
     * @ORM\JoinTable(name="admissions_banks")
     * @ORM\JoinColumn(name="hall_bank_id", referencedColumnName="bank_id")
     */
    private $hall_bank_id;
}
