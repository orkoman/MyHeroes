<?php
/**
 * Created by PhpStorm.
 * User: Z002Y7UA
 * Date: 27.02.2015
 * Time: 12:23
 */

include_once "backend/mainIncludes.php";

include_once MAINDIR . "/backend/classes/clInterface.php";

if (!isset($_SESSION)) {
    session_start();
}

clInterface::drawBegin(array(),array());

if (isset($_SESSION["lastError"]))
{
    $error = $_SESSION["lastError"];
}
else
{
    $error = '';
}

if ($error !== '')
{
    print "<h1>ERROR: $error</h1>";
}
else
{
    //print "<h1>NOERROR</h1>";
}
$_SESSION["lastError"] = "";

print "
                <h2>Login</h2>
                <form action='backend/login.php' method='post'>
                    E-mail: <input type='text' name='email' value='orkoman'/><br/>
                    PW: <input type='password' name='pw' value='123'/><br/>
                    <input type='submit' value='submit'/>
                </form>

                <h2>Register</h2>
                <form action='backend/register.php' method='post'>
                    E-mail: <input type='text' name='email'/><br/>
                    PW: <input type='password' name='pw'/><br/>
                    Confirm: <input type='password' name='pwConfirm'/><br/>
                    <input type='submit' value='submit'/>
                </form>

    ";

clInterface::drawEnd();

?>