<?php

/*
 * This file is part of the Admission System package.
 *
 * (c) Gad Ocansey <gadocansey@gmail.com>
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 */

namespace App\Repository;

use Doctrine\ORM\EntityRepository;

/**
 * This custom Doctrine repository is empty because so far we don't need any custom
 * method to query for application user information. But it's always a good practice
 * to define a custom repository that will be used when the application grows.
 *
 * See https://symfony.com/doc/current/book/doctrine.html#custom-repository-classes
 *
 * @author Gad Ocansey <gadocansey@gmail.com>
 */
class CountryRepository extends EntityRepository
{
    public function createAlphabeticalQueryBuilder()
    {


        $queryBuilder = $this->createQueryBuilder('c');
        $query = $queryBuilder
            ->where($queryBuilder->expr()->notIn('c.id', 239));

        return   $query;
    }


    /*public function queryOwnedBy($user) {

        $query = $this->createQueryBuilder('a')
            ->from('MyBundle:Article', 'a')
            ->innerJoin('a.owndBy', 'u')
            ->where('u.id = :id')
            ->setParameter('id', $user->getId());

        return $query;
    }*/
}
