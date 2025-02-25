<?php
    session_start();
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="style.css">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=SUSE:wght@100..800&display=swap" rel="stylesheet">
    <script src="https://kit.fontawesome.com/791dbbf45c.js" crossorigin="anonymous"></script>
    <title>Document</title>
</head>
<body>
    <header>
        <div class="logo">
            Shop
        </div>
        <div class="headerButtons">
            <i class="fa-solid fa-shop"></i>
            <i class="fa-solid fa-cart-shopping"></i>
            <i class="fa-solid fa-right-from-bracket"></i>
        </div>
    </header>
    <h1 class="welcomeText">Welcome To Our Shop</h1>
    <h2 class="welcomeText2">Where We Sell Only The Best Computer Parts</h2>
    <div class="searchBar">
        <input class="inputSearchBar"></input>
        <i class="fa-solid fa-magnifying-glass"></i>
    </div>
    <div class="items">
        <?php
            // $conn = mysqli_connect('localhost', 'root', '', 'sklep2');
            // $sql = 'select * from inventory';
            // $result = mysqli_query($conn, $sql);
            // while($row = mysqli_fetch_row($result)) {
            //     echo "<div class='item'>"
            // }
        ?>
        <div class="row">
            <div class="item">
                <img src="media/4070GamingOC.png" alt="">
                <div class="title">Graphics Card 4070 Gaming OC</div>
                <div class="price">399.99$</div>
            </div>
            <div class="item"></div>
            <div class="item"></div>
            <div class="item"></div>
        </div>
    </div>
</body>
</html>