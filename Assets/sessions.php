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

$sessionStart = $_REQUEST["sessionStart"];
$sessionEnd = $_REQUEST["sessionEnd"];

$sql = "INSERT INTO UsersInfo (TimeLogin, TimeLogout) VALUES ('$sessionStart','$sessionEnd')";
UPDATE Sessions SET TimeLogout = $_REQUEST["sessionEnd"];
WHERE SessionID = $_RESQUEST["sessionEnd"];

if ($conn->query($sql) === TRUE) {
    echo "New record created successfully";
  } else {
    echo "Error: " . $sql . "<br>" . $conn->error;
  }

echo "FINISHED";
?>