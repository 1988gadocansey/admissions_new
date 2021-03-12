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
/**
 * @ORM\Table(name="admission_formNumber")
 * @ORM\Entity
 */
class FormNo
{
    /**
     * @ORM\Entity(repositoryClass="App\Repository\FormNoRepository")
     * @ORM\Table(name="admission_formNumber")
     *
     * Defines the properties of the User entity to represent the application users.
     * See https://symfony.com/doc/current/book/doctrine.html#creating-an-entity-class
     *
     * Tip: if you have an existing database, you can generate these entity class automatically.
     * See https://symfony.com/doc/current/cookbook/doctrine/reverse_engineering.html
     *
     */

    /**
     * @var int
     *
     * @ORM\Id
     * @ORM\GeneratedValue
     * @ORM\Column(type="integer")
     */
    private $id;

    /**
     * @var string
     * @ORM\Column(type="string")
     */

    private $number;

    /**
     * @return int
     */
    public function getId(): int
    {
        return $this->id;
    }

    /**
     * @param int $id
     */
    public function setId(int $id)
    {
        $this->id = $id;
    }

    /**
     * @return string
     */
    public function getNumber(): string
    {
        return $this->number;
    }

    /**
     * @param string $number
     */
    public function setNumber(string $number)
    {
        $this->number = $number;
    }

}