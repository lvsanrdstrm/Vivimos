import { useContext } from 'react'
import { useParams, useNavigate } from 'react-router-dom'
import { GlobalContext } from '../GlobalContext'

export const handleBidClick = async (id, navigate, activeUser) => {
  if (activeUser.loggedIn) {
    try {
      const requestOptions = {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
          ad: id,
          bid: activeUser.ad, // Assuming activeUser.ad is the ad ID
        }),
      };

      await fetch(`/api/ad/${id}/bid`, requestOptions);


      if (requestOptions.ok) {
        var userData = await requestOptions.json();
        userData = JSON.parse(userData);
        console.log(userData)

      } else {
        console.error('Error authenticating user:', error);
      }

      alert('Ditt bud har sparats.');
      navigate('/');

    } catch (error) {
      console.error('Error adding bid:', error);
      console.log(userData)
      alert('Ett fel inträffade vid sparandet av ditt bud.');
    }
  } else {
    alert('Du måste logga in för att kunna lägga ett bud.');
  }
}

function ConfirmBid() {
  const { id } = useParams()
  const navigate = useNavigate()
  const { activeUser } = useContext(GlobalContext)

  const handleClick = () => {
    handleBidClick(id, navigate, activeUser);
  }

  return (
    <div>
      <h2>Bekräfta bud</h2>
      <p>Auktion: {id}</p>
      <button onClick={handleClick}>Lägg ditt bud</button>
    </div>
  )
}

export default ConfirmBid
