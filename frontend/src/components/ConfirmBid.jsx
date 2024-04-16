import { useParams, useNavigate } from 'react-router-dom'

function ConfirmBid() {
  const { id } = useParams()
  const navigate = useNavigate()

  function submitBid(e) {
    handleBidClick(navigate, e);
  }

  return (
    <form onSubmit={submitBid} method="POST" action={`/api/bids/${id}`}>
      <h2>Bekräfta bud</h2>
      <p>Auktion: {id}</p>
      <input type="submit" value="Lägg ditt bud"></input>
    </form>
  )
}

async function handleBidClick(navigate, e) {
  e.preventDefault()

  const requestOptions = {
    method: e.target.method,
    headers: {
      'Content-Type': 'application/json',

    },
    credentials: "same-origin",
    body: JSON.stringify("{}")

  };

  let result = await fetch(e.target.action, requestOptions);


  if (result.ok) {
    var userData = await result.json();
    console.log(userData)
    alert('Ditt bud har sparats.');
    navigate('/');

  } else if (result.status == 400) {
    alert("Något var fel med din data när vi försökte spara ditt bud")
  } else if (result.status == 404) {
    alert("Du måste vara inloggad för att lägga bud")
  } else {
    alert("Något gick fel när vi försökte spara ditt bud")
  }




}
export default ConfirmBid
