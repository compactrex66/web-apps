<?php

function conn() {
    $login = 'kmirecki';
    $pass = '12853902A';
    $addres = 'localhost';
    $base = 'kmirecki';

    $polaczenie = mysqli_connect($addres, $login, $pass, $base);

    return $polaczenie;
}

function rozlacz($polaczenie) {
    $polaczenie -> close();
}

?>