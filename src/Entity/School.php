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
 * @ORM\Table(name="schools")
 *
 * Defines the properties of the Region entity to represent the applicant region.
 * @author Gad Ocansey <gadocansey@gmail.com>
 */
class School implements \JsonSerializable
{
    /**
     * @var int
     *
     * @ORM\Id
     * @ORM\GeneratedValue
     * @ORM\Column(type="integer")
     */
    private $id;

    /**
     * @var ArrayCollection
     * @ORM\OneToMany(targetEntity="App\Entity\Applicant",mappedBy="school")
     */
    private $applicant;

    public function __construct()
    {
        $this->applicant=new ArrayCollection();
    }

    /**
     * @var string
     *
     * @ORM\Column(type="string", unique=true)
     */
    private $name;

    /**
     * @return string
     */
    public function getRegion(): string
    {
        return $this->region;
    }

    /**
     * @param string $region
     */
    public function setRegion(string $region)
    {
        $this->region = $region;
    }

    /**
     * @return string
     */
    public function getLocation(): string
    {
        return $this->location;
    }

    /**
     * @param string $location
     */
    public function setLocation(string $location)
    {
        $this->location = $location;
    }

    /**
     * @var string
     *
     * @ORM\Column(type="string")
     */
    private $region;

    /**
     * @var string
     *
     * @ORM\Column(type="string")
     */
    private $location;

    public function getId(): int
    {
        return $this->id;
    }

    public function setName(string $name): void
    {
        $this->name = $name;
    }

    public function getName(): string
    {
        return $this->name;
    }
    public function getApplicant()
    {
        return $this->applicant;
    }

    /**
     * {@inheritdoc}
     */
    public function jsonSerialize(): string
    {
        // This entity implements JsonSerializable (http://php.net/manual/en/class.jsonserializable.php)
        // so this method is used to customize its JSON representation when json_encode()
        // is called, for example in tags|json_encode (app/Resources/views/form/fields.html.twig)

        return $this->name;
    }

    public function __toString(): string
    {
        return $this->name;
    }

    public function addApplicant(Applicant $applicant): self
    {
        if (!$this->applicant->contains($applicant)) {
            $this->applicant[] = $applicant;
            $applicant->setSchool($this);
        }

        return $this;
    }

    public function removeApplicant(Applicant $applicant): self
    {
        if ($this->applicant->contains($applicant)) {
            $this->applicant->removeElement($applicant);
            // set the owning side to null (unless already changed)
            if ($applicant->getSchool() === $this) {
                $applicant->setSchool(null);
            }
        }

        return $this;
    }
}
