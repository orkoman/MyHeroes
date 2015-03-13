<?php
/**
 * Created by PhpStorm.
 * User: z002y7ua
 * Date: 13.03.2015
 * Time: 13:52
 */

include_once "dbConnection.php";

class clResource {
    public static $s_id = 0;
    public function clResource($_name,$_startAmount)
    {
        self::$s_id ++;
        $this->id = self::$s_id;
        $this->name = $_name;
        $this->startAmount = $_startAmount;
    }

    public function requestData()
    {
        return ($this->name);
    }

    public function createResource($_maxAmount)
    {
        $castle_id = clGameFactory::selectCastleID(); //TODO must be moved from gameFactory
        $resource_id = $this->id;
        $amount = $this->startAmount;

        if (dbConnection::connect()) {
            $sql = "INSERT INTO castleresources (castle_id, resource_id,amount,maxAmount)
                              VALUES ($castle_id,$resource_id,$amount,$_maxAmount)";
            if (dbConnection::$connectionID->query($sql) === TRUE) {
                return true;
            } else {
                $_SESSION["lastError"] = $_SESSION["lastError"]."Error in database while insert resources $castle_id,$resource_id,$amount,$_maxAmount";
                return false;
            }
        }
        $_SESSION["lastError"] = $_SESSION["lastError"].'Couldnot createResource '.$this->name.' ';
        return false;
    }
}