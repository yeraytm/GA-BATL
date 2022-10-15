<?php
$servername = "localhost";
$username = "yeraytm";
$password = "TeKhudcX6W";
$db = "yeraytm";

$conn = mysqli_connect($servername, $username, $password, $db);

if(!$conn) {
    die("ERROR: Connection failed: " . mysqli_connect_error());
}

$name = $_REQUEST["name"];
$country = $_REQUEST["country"];
$installDate = $_REQUEST["installDate"];

$sql = "INSERT INTO UsersInfo (UserName, Country, DateOfInstall) VALUES ('$name','$country', '$installDate')";

if ($conn->query($sql) === TRUE) {
    $user_id = $conn->insert_id;
    echo $user_id;
  }
?>