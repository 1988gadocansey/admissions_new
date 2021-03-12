<?php
/**
 * Created by PhpStorm.
 * User: gadoo
 * Date: 27/01/2018
 * Time: 6:29 PM
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
class RegionRepository extends EntityRepository
{
    public function createAlphabeticalQueryBuilder()
    {
        return $this->createQueryBuilder('regions')
            ->orderBy('regions.name', 'ASC');
    }
}