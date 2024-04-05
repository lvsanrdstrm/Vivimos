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
      let items = await response.json()
      items = items.filter(item => item.adActive === true)
      console.log(response)
      setItems(items)
      setAds(items)
      setFilteredAds(items)
    }
    load()
  }, [])

  return <section>
    <h2 className="current">Aktuella auktioner:</h2>

    {filteredAds?.map(ItemCard)}

  </section>

  function ItemCard(ad) {

    const { id, headline, gender, age, city, county, occupation, endDate } = ad

    const handleOfferButton = () => {
      navigate(`/ad/${id}/bid`)
    }

    return (
      <div className='itemCard-container' key={id}>
        <div className='ad-info'>

          <h3 className="ad-title"><Link to={`/ad/${id}`}>{headline}</Link></h3>
          <p>En {age} år gammal {gender.toLowerCase()}, från {county} <br /> som är {occupation.toLowerCase()} och bor i {city.toLowerCase()}.</p>&nbsp;
          <p>Denna annons är aktiv till och med {endDate}.</p>


        </div>
        {/*<div className='ad-right'>
          {bids && bids.includes(activeUser.id) ? (<img className='bidPaddle' src={bidpaddle}></img>) : null}
          {bids ? (<p className="antalBud">Antal bud: {bids.length}</p>) : null}
          <div class="button-container">
            <button onClick={handleOfferButton}>Lägg ett bud</button>
          </div>
    </div>*/}
      </div>
    )
  }


}






export default AdList