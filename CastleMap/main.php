<?php
/**
 * Created by PhpStorm.
 * User: Z002Y7UA
 * Date: 27.02.2015
 * Time: 14:12
 */

session_start();
include_once "mainIncludes.php";

if (isset($_SESSION['id'])) {

    include_once MAINDIR . "/classes/clInterface.php";
    include_once MAINDIR . "/classes/clServer.php";

    clInterface::drawBegin(array('main.css'), array('utils.js','people.js','map.js','resources.js','game.js'));

    clInterface::drawRessourceTab();
    clInterface::drawActionTab();
    clInterface::drawMap();

    clInterface::drawEnd();

    $buildings = clServer::getBuildings();
    $nature = clServer::getNature();
    $resources = clServer::getResources();

//TODO OLEG remove this

    print "
    <script type='text/javascript'>
        var g_Game = new clGame('$buildings','$nature','$resources');
    </script>
        ";
}
else
{
    header("Location:".MAINURI."/loginForm.php");
}
?>