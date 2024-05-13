import React, { useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';

function ConfirmBid() {
  const { id } = useParams();
  const navigate = useNavigate();
  const [showConfirmation, setShowConfirmation] = useState(false);

  async function submitBid(e) {
    e.preventDefault();

    const requestOptions = {
      method: e.target.method,
      headers: {
        'Content-Type': 'application/json',
      },
      credentials: 'same-origin',
      body: JSON.stringify("{}"),
    };

    let result = await fetch(e.target.action, requestOptions);

    if (result.ok) {
      setShowConfirmation(true);
    } else if (result.status === 400) {
      alert('Något var fel med din data när vi försökte spara ditt bud');
    } else if (result.status === 404) {
      alert('Du måste vara inloggad för att lägga bud');
    } else {
      alert('Något gick fel när vi försökte spara ditt bud');
    }
  }

  return (
    <form onSubmit={submitBid} method="POST" action={`/api/bids/${id}`}>
      <h2>Bekräfta bud</h2>
      <p>Auktion: {id}</p>
      {!showConfirmation && <input type="submit" value="Lägg ditt bud" />}
      {showConfirmation && <p id="sparatBud">Ditt bud har sparats.</p>}
    </form>
  );
}

export default ConfirmBid;
