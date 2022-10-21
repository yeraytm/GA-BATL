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
$itemID = $_REQUEST["itemID"];
$transactionDate = $_REQUEST["transactionDate"];

$sql = "INSERT INTO Transactions (UserID, ItemID, DateTransaction) VALUES ('$userID', '$itemID','$transactionDate')";

if ($conn->query($sql) === TRUE) {
  $transaction_id = $conn->insert_id;
  echo $transaction_id;
}
?>