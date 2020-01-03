<?php

namespace App\Entity;

use Doctrine\ORM\Mapping as ORM;

/**
 * @ORM\Entity(repositoryClass="App\Repository\ProgrammeRepository")
 */
class Programme
{
    /**
     * @ORM\Id()
     * @ORM\GeneratedValue()
     * @ORM\Column(type="integer")
     */
    private $id;

    /**
     * @ORM\Column(type="string", length=255)
     */
    private $name;

    /**
     * @ORM\Column(type="string", length=255)
     */
    private $code;

    /**
     * @ORM\Column(type="integer")
     */
    private $running;

    /**
     * @ORM\Column(type="string", length=255, nullable=true)
     */
    private $section;

    /**
     * @ORM\Column(type="integer")
     */
    private $duration;

    /**
     * @ORM\Column(type="integer", nullable=true)
     */
    private $showOnPortal;

    /**
     * @ORM\Column(type="string", nullable=true, length=255)
     */
    private $levelAdmitted;

    /**
     * @ORM\Column(type="string", nullable=true)
     */
    private $type;

    /**
     * @return mixed
     */
    public function getType()
    {
        return $this->type;
    }

    /**
     * @param mixed $type
     */
    public function setType($type): void
    {
        $this->type = $type;
    }

    /**
     * @ORM\Column(type="integer")
     */
    private $departmentId;

    public function getId(): ?int
    {
        return $this->id;
    }

    public function getName(): ?string
    {
        return $this->name;
    }

    public function setName(string $name): self
    {
        $this->name = $name;

        return $this;
    }

    public function getCode(): ?string
    {
        return $this->code;
    }

    public function setCode(string $code): self
    {
        $this->code = $code;

        return $this;
    }

    public function getRunning(): ?int
    {
        return $this->running;
    }

    public function setRunning(int $running): self
    {
        $this->running = $running;

        return $this;
    }

    public function getSection(): ?string
    {
        return $this->section;
    }

    public function setSection(?string $section): self
    {
        $this->section = $section;

        return $this;
    }

    public function getDuration(): ?int
    {
        return $this->duration;
    }

    public function setDuration(int $duration): self
    {
        $this->duration = $duration;

        return $this;
    }

    public function getShowOnPortal(): ?int
    {
        return $this->showOnPortal;
    }

    public function setShowOnPortal(int $showOnPortal): self
    {
        $this->showOnPortal = $showOnPortal;

        return $this;
    }

    public function getLevelAdmitted(): ?int
    {
        return $this->levelAdmitted;
    }

    public function setLevelAdmitted(int $levelAdmitted): self
    {
        $this->levelAdmitted = $levelAdmitted;

        return $this;
    }

    public function getDepartmentId(): ?int
    {
        return $this->departmentId;
    }

    public function setDepartmentId(int $departmentId): self
    {
        $this->departmentId = $departmentId;

        return $this;
    }

    public function __toString()
    {
        return $this->name;
    }
}
