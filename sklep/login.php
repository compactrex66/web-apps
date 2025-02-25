<?php
    session_start();
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="styleLogin.css">
    <title>Sklep</title>
</head>
<body>
    <form class="form" method="post">
        <header>Sign in</header>
        <input type="text" placeholder="login" name="login">
        <input type="text" placeholder="password" name="pass">
        <input type="submit" value="Sign in">
</form>

    <?php
        $conn = mysqli_connect('localhost', 'root', '', 'sklep2');

        if(!empty($_POST['login']) && !empty($_POST['pass'])) {
            $_SESSION['login'] = $_POST['login'];
            $_SESSION['pass'] = $_POST['pass'];
            $_SESSION['logedIn'] = false;
            $_SESSION['hasAdminPrivilige'] = false;

            $sql = 'SELECT * FROM `users`;';
            if($result = mysqli_query($conn, $sql)) {
                echo "skibidi";
            }

            while ($row = mysqli_fetch_row($result)) {
                if($row[1] == $_SESSION['login'] && $row[2] == $_SESSION['pass']) {
                    $_SESSION['logedIn'] = true;
                    if($row[3] == "admin") {
                        $_SESSION['hasAdminPrivilige'] = true;
                    }
                    header("Location: index.php");
                }
            }
        }
    ?>
</body>
</html>