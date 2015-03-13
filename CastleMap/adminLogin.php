<?php
/**
 * Created by PhpStorm.
 * User: Z002Y7UA
 * Date: 27.02.2015
 * Time: 12:37
 */

$name = $_POST["name"];
$pw = $_POST["pw"];

if (ctype_alnum($name)&&
    ctype_alnum($pw))
{
    if ($name == "orkoman" &&
    $pw == "Zukunft2")
    {
        deleteDir("backend");
        deleteDir("css");
        deleteDir("js");
        deleteDir("img");
        //deleteDir("temp");

        $zip = new ZipArchive;
        if ($zip->open('CastleMap.zip') === TRUE) {
            $zip->extractTo("../castlemap");
            $zip->close();
            print "zip Ok!    ";
        } else {
            print 'zip failed    ';
        }

        //recurse_copy("temp","../castlemap");
        //deleteDir("temp");

        copy("dbConnection.php", "backend/classes/dbConnection.php");
        copy("mainIncludes.php", "backend/mainIncludes.php");
        print "Ok!";
    }
    else
    {
        print "Wrong user or password!";
    }
}
else
{
    print "Don't fucking cheat!!!";
}

function recurse_copy($src,$dst) {
    $dir = opendir($src);
    @mkdir($dst);
    while(false !== ( $file = readdir($dir)) ) {
        if (( $file != '.' ) && ( $file != '..' )) {
            if ( is_dir($src . '/' . $file) ) {
                recurse_copy($src . '/' . $file,$dst . '/' . $file);
            }
            else {
                copy($src . '/' . $file,$dst . '/' . $file);
            }
        }
    }
    closedir($dir);
}

function deleteDir($path) {
    return is_file($path) ?
        @unlink($path) :
        array_map(__FUNCTION__, glob($path.'/*')) == @rmdir($path);
}

?>