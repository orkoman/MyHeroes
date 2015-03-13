<?php
/**
 * Created by PhpStorm.
 * User: Z002Y7UA
 * Date: 27.02.2015
 * Time: 12:45
 */

include_once "dbConnection.php";
include_once "clGameFactory.php";

class clLogin {

    public static function login($name,$pw)
    {
        //TODO change this
        if (!ctype_alnum($name)||
            !ctype_alnum($pw))
        {
            $_SESSION["lastError"] = "Name or password must be alphabetic or numeric";
            return false;
        }

        if (!self::trySelect($name,$pw))
        {
            $_SESSION["lastError"] = "No such user";
            return false;
        }
        return true;
    }

    public static function register($name,$pw,$pwConfirm)
    {

        //TODO change this
        if (!ctype_alnum($name)||
            !ctype_alnum($pw) ||
            !ctype_alnum($pwConfirm))
        {
            $_SESSION["lastError"] = "Name or password must be alphabetic or numeric";
            return false;
        }

        if (!self::trySelect($name,$pw)) {
            if (dbConnection::connect()) {
                $sql = "INSERT INTO users (name, pw)
                                  VALUES ('$name','$pw')";
                $result = true;
                dbConnection::$connectionID -> autocommit(FALSE);
                if (dbConnection::$connectionID->query($sql) === TRUE) {
                    if (!self::trySelect($name,$pw)) //only for session id
                    {
                        $_SESSION["lastError"] = "After insert cant find user";
                        $result = false;
                    }
                    else {
                        $result = clGameFactory::createCastle();
                    }
                } else {
                    $_SESSION["lastError"] = "Error in database while insert user";
                    $result = false;
                }

                if ($result)
                {
                    dbConnection::$connectionID -> commit();
                }
                else
                {
                    dbConnection::$connectionID -> rollback();
                }

                dbConnection::$connectionID -> autocommit(TRUE);
                return $result;
            }
        }
        else
        {
            $_SESSION["lastError"] = "User already exists";
            return false;
        }
    }

    private static function trySelect($name,$pw)
    {
        //print $name.$pw;
        if (dbConnection::connect()) {
            $sql = "SELECT id FROM users WHERE name = '$name' AND pw='$pw'";

            $result = dbConnection::$connectionID->query($sql);

            if ($result->num_rows > 0) {
                // output data of each row
                if ($row = $result->fetch_assoc()) {
                    $_SESSION["id"] = $row["id"];
                }
            } else {
                return false;
            }
        }
        return true;
    }



}

?>