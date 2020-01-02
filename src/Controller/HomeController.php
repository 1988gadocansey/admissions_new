<?php
/*
 * This file is part of the Admission Software package.
 *
 * (c) Gad Ocansey <gadocansey@gmail.com>
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 */

namespace App\Controller;

use App\Entity\User;
use Doctrine\ORM\Mapping\Entity;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Security;
use Symfony\Bundle\FrameworkBundle\Controller\AbstractController;

/**
 * @Security("is_granted('ROLE_USER')")
 */
class HomeController extends AbstractController
{


    /**
     * @Security("is_granted('ROLE_USER')")
     * @Route("/dashboard", name="dashboard")
     */


    public function indexAction()
    {



        return $this->render('dashboard/dashboard.html.twig');

    }



}