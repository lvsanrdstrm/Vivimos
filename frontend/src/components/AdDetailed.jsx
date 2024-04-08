import { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { Link } from "react-router-dom";
function AdDetailed() {
  const { id } = useParams()
  const [ad, setAd] = useState(null)
  const navigate = useNavigate()


  useEffect(() => {
    fetch('/api/ads')
      .then(response => response.json())
      .then(data => {
        const foundAd = data.find(ad => ad.Id === id);
        setAd(foundAd);
      });
  }, [id]);

  if (!ad) {
    return <div>Vänta medan annonsen laddas...</div>;
  }

  const handleOfferButton = () => {
    navigate(`/ad/${id}/bid`)
  }
  const pronomenLista = {
    man: "Han",
    kvinna: "Hon",
    annat: "Hen"
  };
  const pronomen = pronomenLista[ad.Gender.toLowerCase()];

  const pets = ["Hund", "Katt", "Fågel", "Häst"];
  let petsList = [];

  for (let Pet of pets) {
    if (ad[Pet]) {
      petsList.push(Pet.toLowerCase());
    }
  }
  let kidsSentence = ad.ChildrenNum === "" ? `${pronomen} har inga barn.` : `${pronomen} har ${ad.ChildrenNum} barn`;

  if (ad.ChildrenHome !== "") {
    if (ad.ChildrenHome.toLowerCase() === "ja") {
      kidsSentence += `, som ${pronomen.toLowerCase()} bor tillsammans med.`;
    } else if (ad.ChildrenHome.toLowerCase() === "delvis") {
      kidsSentence += `, som ${pronomen.toLowerCase()} delvis bor tillsammans med.`;
    } else if (ad.ChildrenHome.toLowerCase() === "nej") {
      kidsSentence += `, som ${pronomen.toLowerCase()} inte bor tillsammans med.`;
    }
  }
  const nearby = ["skog", "hav", "kultur", "shopping"].filter(Attraction => ad[Attraction]);
  let nearbySentence = "";

  if (nearby.length > 0) {
    nearbySentence = `${pronomen} bor i närheten av: ${nearby.join(", ")}.`;
  } else {
    nearbySentence = `${pronomen} har inte angivit vad som erbjuds i närområdet.`;
  }


  let petsString = petsList.join(", ");

  let petsSentence = ad.Pets === "" ? `${pronomen} har inga husdjur.` : `${pronomen} har ${petsString}.`;

  if (ad.Other) {
    petsSentence += ` ${pronomen} har även ${ad.Other.toLowerCase()}.`;
  }
  let relStatusSentence = "";

  switch (ad.RelStatus.toLowerCase()) {
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
      <h1>{ad.Headline}</h1>
      <p>{ad.Presentation}</p>
      <p>Annonsören är en {ad.Age} år gammal {ad.Gender.toLowerCase()},
        från {ad.County} län. <br /> {pronomen} bor i {ad.Dwelling.toLowerCase()} i {ad.City.toLowerCase()}. </p>
      <p>{nearbySentence}</p>

      <p>{petsSentence}</p>
      <p>{relStatusSentence}</p>
      <p>{kidsSentence}</p>
      {ad.Occupation && ad.Occupation !== "" && (
        <p>{pronomen} är verksam som {ad.Occupation}</p>
      )}
      {ad.Hobbies && ad.Hobbies !== "" && (
        <p>{pronomen} har angivit följande fritidsintressen: {ad.Hobbies}</p>
      )}
      <p>Denna annons är aktiv till och med {ad.EndDate}.</p>
      {/*ad.bids ? (<p>Antal bud: {ad.bids.length}</p>) : null*/}
      <button onClick={handleOfferButton}>Lägg ett bud</button>
    </div>
  );
}

export default AdDetailed;