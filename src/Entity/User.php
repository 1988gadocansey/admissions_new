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
use Symfony\Component\Security\Core\User\UserInterface;

/**
 * @ORM\Entity(repositoryClass="App\Repository\UserRepository")
 * @ORM\Table(name="admissions_user")
 * @ORM\HasLifecycleCallbacks
 * Defines the properties of the User entity to represent the application users.
 * See https://symfony.com/doc/current/book/doctrine.html#creating-an-entity-class
 *
 * Tip: if you have an existing database, you can generate these entity class automatically.
 * See https://symfony.com/doc/current/cookbook/doctrine/reverse_engineering.html
 *
 *
 *
 */



class User implements UserInterface, \Serializable
{
    /**
     * @return string
     */
    public function getFormNo()
    {
        return $this->formNo;
    }

    /**
     * @param string $formNo
     */
    public function setFormNo ($formNo)
    {
        $this->formNo = $formNo;
    }

    /**
     * @return int
     */
    public function getStarted()
    {
        return $this->started;
    }

    /**
     * @param int $started
     */
    public function setStarted(  $started)
    {
        $this->started = $started;
    }

    /**
     * @return string
     */
    public function getPhone()
    {
        return $this->phone;
    }

    /**
     * @param string $phone
     */
    public function setPhone(  $phone)
    {
        $this->phone = $phone;
    }

    /**
     * @return string
     */
    public function getPin()
    {
        return $this->pin;
    }

    /**
     * @param string $pin
     */
    public function setPin( $pin)
    {
        $this->pin = $pin;
    }

    /**
     * @return int
     */
    public function getFinalized()
    {
        return $this->finalized;
    }

    /**
     * @param int $finalized
     */
    public function setFinalized(  $finalized)
    {
        $this->finalized = $finalized;
    }

    /**
     * @return string
     */
    public function getFormType()
    {
        return $this->formType;
    }

    /**
     * @param string $formType
     */
    public function setFormType( $formType)
    {
        $this->formType = $formType;
    }

    /**
     * @return int
     */
    public function getPictureUploaded()
    {
        return $this->pictureUploaded;
    }

    /**
     * @param int $pictureUploaded
     */
    public function setPictureUploaded(  $pictureUploaded)
    {
        $this->pictureUploaded = $pictureUploaded;
    }

    /**
     * @return int
     */
    public function getFormCompleted()
    {
        return $this->formCompleted;
    }

    /**
     * @param int $formCompleted
     */
    public function setFormCompleted(  $formCompleted)
    {
        $this->formCompleted = $formCompleted;
    }

    /**
     * @return int
     */
    public function getLoginCounter()
    {
        return $this->loginCounter;
    }

    /**
     * @param int $loginCounter
     */
    public function setLoginCounter(  $loginCounter)
    {
        $this->loginCounter = $loginCounter;
    }

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
     *
     * @ORM\Column(type="string",nullable=True)
     */
    private $formNo;
    /**
     * @var int
     *
     * @ORM\Column(type="integer")
     */
    private $started;
    /**
     * @var string
     *
     * @ORM\Column(type="string")
     */
    private $fullName;

    /**
     * @return mixed
     */
    public function getLastLogin()
    {
        return $this->lastLogin;
    }

    /**
     * @param mixed $lastLogin
     */
    public function setLastLogin($lastLogin)
    {
        $this->lastLogin = $lastLogin;
    }
    /**
     * @var datetime $created
     *
     * @ORM\Column(type="datetime")
     */
    protected $createdAt;

    /**
     * @var datetime $updated
     *
     * @ORM\Column(type="datetime", nullable = true)
     */
    protected $updatedAt;


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

    /**
     * @var \DateTime()
     * @ORM\Column(type="datetime")


     */
    private $lastLogin;

    /**
     * @var string
     *
     * @ORM\Column(type="string", unique=true)
     */
    private $username;

    /**
     * @var string
     *
     * @ORM\Column(type="string", unique=true)
     */
    private $email;

    /**
     * @return string
     */
    public function getSoldBy(): string
    {
        return $this->sold_by;
    }

    /**
     * @param string $sold_by
     */
    public function setSoldBy(string $sold_by): void
    {
        $this->sold_by = $sold_by;
    }

    /**
     * @return string
     */
    public function getSold(): string
    {
        return $this->sold;
    }

    /**
     * @param string $sold
     */
    public function setSold(string $sold): void
    {
        $this->sold = $sold;
    }

    /**
     * @return string
     */
    public function getYear(): string
    {
        return $this->year;
    }

    /**
     * @param string $year
     */
    public function setYear(string $year): void
    {
        $this->year = $year;
    }

    /**
     * @var string
     *
     * @ORM\Column(type="string")
     */
    private $sold;

    /**
     * @var string
     *
     * @ORM\Column(type="string")
     */
    private $year;

    /**
     * @var string
     *
     * @ORM\Column(type="string")
     */
    private $sold_by;

    /**
     * @var string
     *
     * @ORM\Column(type="string")
     */
    private $password;

    /**
     * @var string
     *
     * @ORM\Column(type="string")
     */
    private $phone;

    /**
     * @var string
     *
     * @ORM\Column(type="string")
     */
    private $pin;

    /**
     * @var int
     *
     * @ORM\Column(type="integer")
     */
    private $finalized;

    /**
     * @var string
     *
     * @ORM\Column(type="string")
     */
    private $formType;

    /**
     * @var int
     *
     * @ORM\Column(type="integer")
     */
    private $pictureUploaded;


    /**
     * @var int
     *
     * @ORM\Column(type="integer")
     */
    private $formCompleted;


    /**
     * @var int
     *
     * @ORM\Column(type="integer")
     */
    private $loginCounter;

    /**
     * @var array
     *
     * @ORM\Column(type="json_array")
     */
    private $roles = [];

    public function getId(): int
    {
        return $this->id;
    }

    public function setFullName(string $fullName): void
    {
        $this->fullName = $fullName;
    }

    public function getFullName(): string
    {
        return $this->fullName;
    }

    public function getUsername(): string
    {
        return $this->username;
    }

    public function setUsername(string $username): void
    {
        $this->username = $username;
    }

    public function getEmail(): string
    {
        return $this->email;
    }

    public function setEmail(string $email): void
    {
        $this->email = $email;
    }

    public function getPassword(): string
    {
        return $this->password;
    }

    public function setPassword(string $password): void
    {
        $this->password = $password;
    }

    /**
     * Returns the roles or permissions granted to the user for security.
     */
    public function getRoles(): array
    {
        $roles = $this->roles;

        // guarantees that a user always has at least one role for security
        if (empty($roles)) {
            $roles[] = 'ROLE_USER';
        }

        return array_unique($roles);
    }

    public function setRoles(array $roles): void
    {
        $this->roles = $roles;
    }

    /**
     * Returns the salt that was originally used to encode the password.
     *
     * {@inheritdoc}
     */
    public function getSalt(): ?string
    {
        // See "Do you need to use a Salt?" at https://symfony.com/doc/current/cookbook/security/entity_provider.html
        // we're using bcrypt in security.yml to encode the password, so
        // the salt value is built-in and you don't have to generate one

        return null;
    }

    /**
     * Removes sensitive data from the user.
     *
     * {@inheritdoc}
     */
    public function eraseCredentials(): void
    {
        // if you had a plainPassword property, you'd nullify it here
        // $this->plainPassword = null;
    }

    /**
     * {@inheritdoc}
     */
    public function serialize(): string
    {
        return serialize([
            $this->id,
            $this->username,
            $this->password,
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
