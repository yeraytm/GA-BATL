<?php
$servername = "localhost";
$username = "yeraytm";
$password = "TeKhudcX6W";
$db = "yeraytm";

$conn = mysqli_connect($servername, $username, $password, $db);

if(!$conn) {
    die("ERROR: Connection failed: " . mysqli_connect_error());
}

$userID = $_REQUEST["userID"];
$sessionStart = $_REQUEST["sessionStart"];

$sql = "INSERT INTO Sessions (UserID, TimeLogin) VALUES ('$userID','$sessionStart')";

if ($conn->query($sql) === TRUE) {
    $session_id = $conn->insert_id;
    echo $session_id;
}
?>