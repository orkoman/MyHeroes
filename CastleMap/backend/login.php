<?php
/**
 * Created by PhpStorm.
 * User: Z002Y7UA
 * Date: 27.02.2015
 * Time: 12:37
 */

session_start();

include_once 'mainIncludes.php';

include_once "classes/clLogin.php";

if (clLogin::login($_POST["email"],$_POST["pw"]))
{
    if ($_SESSION["lastError"] !== '')
    {
        $_SESSION["lastError"] = "Bad case must be checked ".$_SESSION["lastError"];

        header("Location:".MAINURI."/loginForm.php");

    }
    else
    {
        header("Location:".MAINURI."/main.php");
    }
}
else
{
    header("Location:".MAINURI."/loginForm.php");
}

?>