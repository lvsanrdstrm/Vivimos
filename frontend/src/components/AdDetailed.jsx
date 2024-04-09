import { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { Link } from "react-router-dom";
function AdDetailed() {
  const { id } = useParams()
  const [ad, setAd] = useState(null)
  const navigate = useNavigate()


  useEffect(() => {

    async function load(){
      const response = await fetch(`/api/ad/${id}`)
      console.log(response)
      let item = await response.json()
      console.log(item)
    }
    load()
    /*fetch('/api/ads')
      .then(response => response.json())
      .then(data => {
        const foundAd = data.find(ad => ad.id === id);
        setAd(foundAd)
      });*/
  }, [id]);

  if (!ad) {
    return <div>Vänta medan annonsen laddas...</div>;
  }
/*
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
  */


  const handleOfferButton = () => {
    navigate(`/ad/${id}/bid`)
  }
  const pronomenLista = {
    man: "Han",
    kvinna: "Hon",
    annat: "Hen"
  };
  const pronomen = pronomenLista[ad.gender.toLowerCase()];

  const pets = ["Hund", "Katt", "Fågel", "Häst"];
  let petsList = [];

  for (let pet of pets) {
    if (ad[pet]) {
      petsList.push(pet.toLowerCase());
    }
  }
  let kidsSentence = ad.childrenNum === "" ? `${pronomen} har inga barn.` : `${pronomen} har ${ad.childrenNum} barn`;

  if (ad.childrenHome !== "") {
    if (ad.childrenHome.toLowerCase() === "ja") {
      kidsSentence += `, som ${pronomen.toLowerCase()} bor tillsammans med.`;
    } else if (ad.childrenHome.toLowerCase() === "delvis") {
      kidsSentence += `, som ${pronomen.toLowerCase()} delvis bor tillsammans med.`;
    } else if (ad.childrenHome.toLowerCase() === "nej") {
      kidsSentence += `, som ${pronomen.toLowerCase()} inte bor tillsammans med.`;
    }
  }
  const nearby = ["skog", "hav", "kultur", "shopping"].filter(attraction => ad[attraction]);
  let nearbySentence = "";

  if (nearby.length > 0) {
    nearbySentence = `${pronomen} bor i närheten av: ${nearby.join(", ")}.`;
  } else {
    nearbySentence = `${pronomen} har inte angivit vad som erbjuds i närområdet.`;
  }


  let petsString = petsList.join(", ");

  let petsSentence = ad.pets === "" ? `${pronomen} har inga husdjur.` : `${pronomen} har ${petsString}.`;

  if (ad.other) {
    petsSentence += ` ${pronomen} har även ${ad.other.toLowerCase()}.`;
  }
  let relStatusSentence = "";

  switch (ad.relStatus.toLowerCase()) {
    case "ensamvarg":
      relStatusSentence = `${pronomen} är en övertygad singel, en ensamvarg.`;
      break
    case "exklusiv särbo":
      relStatusSentence = `${pronomen} är i ett exklusivt särboförhållande.`;
      break;
    case "exklusiv sambo":
      relStatusSentence = `${pronomen} är i ett exklusivt samboförhållande.`;
      break;
    case "öppen särbo":
      relStatusSentence = `${pronomen} är i ett öppet särboförhållande.`;
      break;
    case "öppen sambo":
      relStatusSentence = `${pronomen} är sambo, i ett öppen relation.`;
      break;
    case "singel":
      relStatusSentence = `${pronomen} är singel, men öppen för nya relationer.`;
      break;
    default:
      relStatusSentence = `${pronomen} har inte angivit sin relationsstatus.`;
  }



  return (
    <div>
      <h1>{ad.headline}</h1>
      <p>{ad.presentation}</p>
      <p>Annonsören är en {ad.age} år gammal {ad.gender.toLowerCase()},
        från {ad.county} län. <br /> {pronomen} bor i {ad.dwelling.toLowerCase()} i {ad.city.toLowerCase()}. </p>
      <p>{nearbySentence}</p>

      <p>{petsSentence}</p>
      <p>{relStatusSentence}</p>
      <p>{kidsSentence}</p>
      {ad.occupation && ad.occupation !== "" && (
        <p>{pronomen} är verksam som {ad.occupation}</p>
      )}
      {ad.hobbies && ad.hobbies !== "" && (
        <p>{pronomen} har angivit följande fritidsintressen: {ad.hobbies}</p>
      )}
      <p>Denna annons är aktiv till och med {ad.endDate}.</p>
      {/*ad.bids ? (<p>Antal bud: {ad.bids.length}</p>) : null*/}
      <button onClick={handleOfferButton}>Lägg ett bud</button>
    </div>
  );
}

export default AdDetailed;