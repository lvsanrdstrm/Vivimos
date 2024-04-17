import { useState, useEffect, useContext } from "react"
import { GlobalContext } from "../GlobalContext"
import { Link, useNavigate } from "react-router-dom"
import bidpaddle from '../assets/images/bidpaddle.png'
import '../assets/styles/itemCard.css'

function AdList() {

  const { activeUser, setActiveUser } = useContext(GlobalContext)
  const { ads, setAds } = useContext(GlobalContext)
  const { filteredAds, setFilteredAds } = useContext(GlobalContext)
  const navigate = useNavigate()
  const [items, setItems] = useState([])

  useEffect(() => {
    async function load() {
      const response = await fetch('/api/ads')
      console.log(response)
      let items = await response.json()
      console.log(items)
      console.log(items[0].AdActive)
      items = items.filter(item => item.AdActive === true)
      console.log(items)
      setItems(items)
      setAds(items)
      console.log(ads)
      setFilteredAds(items)
    }
    load()
  }, [])

  return <section>
    <h2 className="current">Aktuella auktioner:</h2>

    {filteredAds?.map(ItemCard)}

  </section>

  function ItemCard(ad) {
    console.log(ad)
    const { Id, Headline, Gender, Age, City, County, Occupation, EndDate } = ad

    const handleOfferButton = () => {
      navigate(`/ad/${Id}/bid`)
    }

    return (
      <div className='itemCard-container' key={Id}>
        <div className='ad-info'>

          <h3 className="ad-title"><Link to={`/ad/${Id}`}>{Headline}</Link></h3>

          <p>Denna annons tillhör en {Gender} i {Age}-årsåldern som bor i det ansika {City} i den vackra provinsen av {County}. Dennes sysselsättning är {Occupation}.</p>
          <p>Låter det spännande? Klicka på rubriken för artt upptäcka mer om detta fascinerande liv!</p>
          <p>Denna annons är aktiv till och med {EndDate}.</p>


        </div>
        {<div className='ad-right'>
          {activeUser.loggedIn && activeUser.ad && activeUser.ad === ad.Id ? (
            <img className='bidPaddle' src={bidpaddle} alt="Bid paddle"></img>
          ) : null}
          /*{ad.bids ? (
            <p className="antalBud">Antal bud: {ad.bids.length}</p>
          ) : null}*/
          <div className="button-container">
            {activeUser.loggedIn ? (
              <button onClick={() => handleOfferButton(ad.Id)}>Lägg ett bud</button>
            ) : (
              <button onClick={() => alert("Du måste logga in för att kunna lägga ett bud.")}>Lägg ett bud</button>
            )}
          </div>
        </div>}

      </div>
    )
  }


}






export default AdList