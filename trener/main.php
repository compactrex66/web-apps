<?php ob_start(); ?>
<div class="about">
            <div class="desc">
                <h1>O mnie</h1>
                Cześć mam na imię Ania i jestem trenerką personalna, medyczną oraz instruktorem korektywy i kompensacji wad postawy. Na co dzień pracuję w firmie Zdrofit oraz jestem współwłaścicielem kliniki fizjoterapii. Pomagam wielu moim podopiecznych czerpać dużo radości z podejmowania aktywności fizycznej, uczę świadomości własnego ciała i pomagam wyznaczyć najskuteczniejsza drogę do osiągnięcia pożądanych celów biorąc pod uwagę profilaktykę zdrowotną oraz żywieniową. Specjalizuję się w treningu siłowym, funkcjonalnym lecz szczególną uwagę przykładam do koordynacji ruchowej. Cały czas podnoszę swoje kompetencje oraz nie boję się wyzwań. Trenuję również kobiety w trakcie ciąży jak i pomagam odzyskać sylwetkę po.
            </div>
            <hr>
            <div class="karty">
                <div class="row">
                    <div class="karta">
                        <h3>Doświadczenie zawodowe</h3>
                        6 lat
                    </div>
                    <div class="karta">
                        <h3>Doświadczenie treningowe</h3>
                        7 lat
                    </div>
                    <div class="karta">
                        <h3>Trening grupowy</h3>
                        Tak
                    </div>
                </div>
                <div class="row">
                    <div class="karta">
                        <h3>Trening z dojazdem do klienta</h3>
                        Nie
                    </div>
                    <div class="karta">
                        <h3>Długość treningu</h3>
                        60 minut
                    </div>
                    <div class="karta">
                        <h3>Cena treningu zawiera</h3>
                        Każdy trening dobierany jest indywidualnie do potrzeb podopiecznego.
                    </div>
                </div>
                <div class="row">
                    <div class="karta">
                        <h3>Prowadzę treningi</h3>
                        W klubie
                    </div>
                    <div class="karta">
                        <h3>Klub</h3>
                        Zdrofit Bemowo, Zdrofit Ochota, Zdrofit Ochota Al. Jerozolimskie, Zdrofit Piastów, Zdrofit ursus
                    </div>
                    <div class="karta">
                        <h3>Dzielnica</h3>
                        Piastów, Bemowo, Ochota, Ursus
                    </div>
                </div>
            </div>
            <hr>
            <h1>cennik</h1>
            Od 150 zł do 200 zł
        </div>
<div class="container-fluid">
    <div class="row content justify-content-center">
        <div class="d-flex justify-content-center" style="align-self: center;">
            <div class="card col-5">
            <h2>Rezerwacje</h2>
            <h4 class="date">
                <?php
                    echo date("m / Y");
                ?>
            </h4>
                <div class="d-flex card-body flex-row flex-wrap justify-content-center">
                    <?php
                        $sql = 'SELECT dzien FROM `rezerwacje`';
                        $result = mysqli_query($conn, $sql);
                        $reservedDays = mysqli_fetch_array($result);
                        $isReserved = false;
                        $nextMonth = false;
                        $month = idate("m");
                        $amountOfDays;
                        if($month % 2 == 0) {
                            if($month != 2) {
                                $amountOfDays = 30;
                            } else {
                                $amountOfDays = 28;
                            }
                        } else {
                            $amountOfDays = 31;
                        }
                        $i = 0;
                        while($row = mysqli_fetch_array($result)) {
                            $reservedDays[$i] = $row[0];
                            $i++;
                        }
                        
                        for($i = 1; $i < $amountOfDays+1; $i ++) {
                            foreach($reservedDays as $day) {
                                if($i == (int)$day) {
                                    $isReserved = true;
                                }
                            }
                            if ($isReserved) {
                                echo"
                                <div class='card kali m-1 reserved'>
                                    <div class='card-body day' id='kal$i' onclick='klik($i)'>
                                        $i
                                    </div>
                                </div>";
                                $isReserved = false;
                            } else {
                                echo"
                                <a href='#offcanvasExample' data-bs-toggle='offcanvas' data-bs-target='#demo'
                                    role='button'>
                                    <div class='card kali m-1 notReserved'>
                                        <div class='card-body day' id='kal$i' onclick='klik($i)'>
                                            $i
                                        </div>
                                    </div>
                                </a>";
                            }
                        }
                        for($i = 1; $i < 36 - $amountOfDays; $i++) {
                            echo"
                                <div class='card kali m-1 nextMonth'>
                                    <div class='card-body day' id='kal$i' onclick='klik($i)'>
                                        $i
                                    </div>
                                </div>";
                                $isReserved = false;
                        }
                    ?>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="offcanvas offcanvas-start" id="demo">
  <div class="offcanvas-header">
    <h1 class="offcanvas-title">Rezerwacje</h1>
    <button type="button" class="btn-close text-reset" data-bs-dismiss="offcanvas"></button>
  </div>
  <div class="offcanvas-body">
    
    <div id="body-kal">
        <form action="" method="post">
            <input type="number" id="inputDay" name="dzien" style="display: none">
            <span id="daySpan"></span>
            <span> <?php echo date(" / m / Y") ?> </span><br>
            <label>Wybierz godzinę: </label>
            <select name="hour">
                <?php 
                    $sql = "select godzina from rezerwacje where dzien=";
                ?>
                <option value="8">8:00</option>
                <option value="10">10:00</option>
                <option value="12">12:00</option>
                <option value="18">18:00</option>
                <option value="20">20:00</option>
            </select><br>
            <button class="btn btn-primary">Zapisz</button>
        </form>
    </div>
  </div>
</div>
<?php
    if(isset($_POST['dzien'])) {
        if(!in_array($_POST['dzien'], $reservedDays)) {
            $day = $_POST['dzien'];
            $hour = $_POST['hour'];
            $sql = 'INSERT INTO `rezerwacje`(`dzien`, `Godzina`) VALUES ('.$day.','.$hour.')';
            echo $day." ".$hour;
            mysqli_query($conn, $sql);
        }
        header("Refresh:0");
    }
?>