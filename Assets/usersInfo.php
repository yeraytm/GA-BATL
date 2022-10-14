<?php
$servername = "localhost";
$username = "yeraytm";
$password = "TeKhudcX6W";
$db = "yeraytm";

$conn = mysqli_connect($servername, $username, $password, $db);

if(!$conn) {
    die("ERROR: Connection failed: " . mysqli_connect_error());
}
echo "Connection success! ";

echo "Received Name: ". $_REQUEST["name"]. " success!";

$name = $_REQUEST["name"];
$country = $_REQUEST["country"];
$installDate = $_REQUEST["installDate"];

// $yearOfBirth =1988;
// $country = "Pamplona";
// $installDate = "2022-07-08 22:55:47";

$sql = "INSERT INTO UsersInfo (UserName, Country, DateOfInstall) VALUES ('$name','$country', '$installDate')";


if ($conn->query($sql) === TRUE) {
    echo "New record created successfully";
  } else {
    echo "Error: " . $sql . "<br>" . $conn->error;
  }

echo "FINISHED";
?>