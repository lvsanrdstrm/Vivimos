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
         
          <p>Denna annons är aktiv till och med {EndDate}.</p>


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