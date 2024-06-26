import React, { useState, useContext } from 'react'
import { GlobalContext } from "../GlobalContext"
import { useNavigate } from "react-router-dom"



function Section1({ form, handleChange }) {

  return (
    <>
      <h1>Skapa ett erbjudande om livsbyte (1)</h1>
      <h2>Först lite om dig själv</h2>
      <h3>Vilket kön är du?: </h3>
      <label>
        Man
        <input
          type="radio"
          name="gender"
          value="Man"
          checked={form.gender === "Man"}
          onChange={handleChange}
        />
      </label>

      <label>
        Kvinna
        <input
          type="radio"
          name="gender"
          value="Kvinna"
          checked={form.gender === "Kvinna"}
          onChange={handleChange}
        />
      </label>

      <label>
        Annat
        <input
          type="radio"
          name="gender"
          value="Annat"
          checked={form.gender === "Annat"}
          onChange={handleChange}
        />
      </label>

      <h3>Hur gammal är du:</h3>
      <input
        type="number"
        name="age"
        value={form.age}
        onChange={handleChange}
        min="18"
        max="120"
      />
    </>
  );
}


function Section2({ form, handleChange }) {
  return (
    <>
      <h1>Skapa ett erbjudande om livsbyte (2)</h1>
      <h2>Nu lite om ditt boende och din yttre livsmiljö</h2>
      <h3>Vilket län bor du i?</h3>
      <select name="county" value={form.county} onChange={handleChange}>
        <option value="">Välj...</option>
        <option value="Blekinge">Blekinge</option>
        <option value="Dalarna">Dalarna</option>
        <option value="Gotland">Gotland</option>
        <option value="Gävleborg">Gävleborg</option>
        <option value="Halland">Halland</option>
        <option value="Jämtland">Jämtland</option>
        <option value="Jönköping">Jönköping</option>
        <option value="Kalmar">Kalmar</option>
        <option value="Kronoberg">Kronoberg</option>
        <option value="Norrbotten">Norrbotten</option>
        <option value="Skåne">Skåne</option>
        <option value="Stockholm">Stockholm</option>
        <option value="Södermanland">Södermanland</option>
        <option value="Uppsala">Uppsala</option>
        <option value="Värmland">Värmland</option>
        <option value="Västerbotten">Västerbotten</option>
        <option value="Västernorrland">Västernorrland</option>
        <option value="Västmanland">Västmanland</option>
        <option value="Västra Götaland">Västra Götaland</option>
        <option value="Örebro">Örebro</option>
        <option value="Östergötland">Östergötland</option>
      </select>


      <h3>Primär typ av boende under livsbytesperioden:</h3>
      <label>
        Lägenhet
        <input type="radio" name="dwelling" value="Lägenhet" checked={form.dwelling === "Lägenhet"}
          onChange={handleChange} />
      </label>
      <label>
        Villa
        <input type="radio" name="dwelling" value="Villa" checked={form.dwelling === "Villa"} onChange={handleChange} />
      </label>
      <label>
        Gård
        <input type="radio" name="dwelling" value="Gård" checked={form.dwelling === "Gård"} onChange={handleChange} />
      </label>
      <label>
        Sommarstuga
        <input type="radio" name="dwelling" value="Sommarstuga" checked={form.dwelling === "Sommarstuga"}
          onChange={handleChange} />
      </label>
      <label>
        Husvagn
        <input type="radio" name="dwelling" value="Husvagn" checked={form.dwelling === "Husvagn"} onChange={handleChange} />
      </label>
      <label>
        Trappuppgång
        <input type="radio" name="dwelling" value="Trappuppgång" checked={form.dwelling === "Trappuppgång"}
          onChange={handleChange} />
      </label>
      <label>
        Annat, vilket?
        <input type="radio" name="dwelling" value="Annat" checked={form.dwelling === "Annat"} onChange={handleChange} />
        {form.boende === "Annat" && (
          <input type="text" name="dwellingOther" value={form.dwellingOther} onChange={handleChange}
            placeholder="Ange boende" />
        )}
      </label>
      <h3>Bor du i:</h3>
      <select name="city" value={form.city} onChange={handleChange}>
        <option value="">Välj...</option>
        <option value="Storstad">Storstad (100 000+)</option>
        <option value="Mellanstor stad">Mellanstor stad (20 000 - 100 000)</option>
        <option value="Småstad">Småstad (3 000 - 20 000)</option>
        <option value="By">By (3 000-)</option>
        <option value="Bystan">Bystan (befriat från grannar)</option>
      </select>

      {form.stad === "Storstad" || form.city === "Mellanstor stad" ? (
        <select name="cityAlternative" value={form.cityAlternative} onChange={handleChange}>
          <option value="">Välj...</option>
          <option value="Centralt">Centralt</option>
          <option value="Villaförort">Villaförort</option>
          <option value="Betongförort">Betongförort</option>
        </select>
      ) : null}

      <h3>Ditt boende är:</h3>
      <label>
        Naturnära (skog)
        <input type="checkbox" name="forest" checked={form.forest !== ""} onChange={handleChange} />
      </label>
      <label>
        Naturnära (hav/sjö)
        <input type="checkbox" name="sea" checked={form.sea !== ""} onChange={handleChange} />
      </label>
      <label>
        Kulturnära (biografer, teater, muséer, gallerier)
        <input type="checkbox" name="culture" checked={form.culture !== ""} onChange={handleChange} />
      </label>
      <label>
        Shoppingnära
        <input type="checkbox" name="shopping" checked={form.shopping !== ""} onChange={handleChange} />
      </label>
      <h3>Har du bil?</h3>
      <label>
        Ja
        <input
          type="radio"
          name="car"
          value="bil"
          checked={form.car === "bil"}
          onChange={handleChange}
        />
      </label>
      <label>
        Nej
        <input
          type="radio"
          name="car"
          value=""
          checked={form.car === ""}
          onChange={handleChange}
        />
      </label>

      {form.car && (
        <>
          <p>Märke/modell/år:</p>
          <input type="text"
            name="carInfo"
            value={form.carInfo}
            onChange={handleChange} />
        </>
      )}
    </>
  );
}

function Section3({ form, handleChange }) {
  return (
    <>
      <h1>Skapa ett erbjudande om livsbyte (3)</h1>
      <h2>Nu lite om vad du fyller ditt liv med</h2>
      <h3>Vilken sysselsättning har du?:</h3>
      <input type="text"
        name="occupation"
        value={form.occupation}
        onChange={handleChange} />

      <h3>Vad gör du på fritiden? Skriv upp till fem fritidsintressen:</h3>
      <input type="text"
        name="hobbies"
        value={form.hobbies}
        onChange={handleChange} />


    </>
  );
}

function Section4({ form, handleChange }) {
  return (
    <>
      <h1>Skapa ett erbjudande om livsbyte (4)</h1>
      <h2>Nu lite om familj och relationer</h2>
      <h3>Relationsstatus</h3>
      <p>Vilket av följande passar bäst in på dig?</p>
      <label>
        Nöjd ensamvarg
        <input
          type="radio"
          name="relStatus"
          value="singel: ensamvarg"
          checked={form.relStatus === "singel: ensamvarg"}
          onChange={handleChange}
        />
      </label>
      <label>
        Singel på jakt
        <input
          type="radio"
          name="relStatus"
          value="singel"
          checked={form.relStatus === "singel"}
          onChange={handleChange}
        />
      </label>
      <label>
        I en öppen relation (särboende)
        <input
          type="radio"
          name="relStatus"
          value="öppen särbo"
          checked={form.relStatus === "öppen särbo"}
          onChange={handleChange}
        />
      </label>
      <label>
        I en exklusiv relation (särboende)
        <input
          type="radio"
          name="relStatus"
          value="exklusiv särbo"
          checked={form.relStatus === "exklusiv särbo"}
          onChange={handleChange}
        />
      </label>
      <label>
        I en öppen relation (samboende)
        <input
          type="radio"
          name="relStatus"
          value="öppen sambo"
          checked={form.relStatus === "öppen sambo"}
          onChange={handleChange}
        />
      </label>
      <label>
        I en exklusiv relation (samboende)
        <input
          type="radio"
          name="relStatus"
          value="exklusiv sambo"
          checked={form.relStatus === "exklusiv sambo"}
          onChange={handleChange}
        />
      </label>
      <label>
        I en polyrelation
        <input
          type="radio"
          name="relStatus"
          value="poly"
          checked={form.relStatus === "poly"}
          onChange={handleChange}
        />
      </label>
      <label>
        Det är lite knasigt
        <input
          type="radio"
          name="relStatus"
          value="knasigt"
          checked={form.relStatus === "knasigt"}
          onChange={handleChange}
        />
      </label>
      {!form.relStatus.includes("singel") && form.relStatus !== "" && (
        <>
          <p>Namn och ålder på din/a partner/s?:</p>
          <input type="text"
            name="partnerInfo"
            value={form.partnerInfo}
            onChange={handleChange} />
        </>
      )}
      <h3>Har du barn?</h3>
      <label>
        Ja
        <input
          type="radio"
          name="children"
          value="barn"
          checked={form.children === "barn"}
          onChange={handleChange}
        />
      </label>
      <label>
        Nej
        <input
          type="radio"
          name="children"
          value=""
          checked={form.children === ""}
          onChange={handleChange}
        />
      </label>
      {form.children === "barn" && (
        <>
          <h3>Hur många?</h3>
          <input
            type="number"
            name="childrenNum"
            value={form.childrenNum}
            onChange={handleChange}
            min="1"
          />


          <h3>Bor de hos dig?</h3>
          <label>
            Ja
            <input
              type="radio"
              name="childrenHome"
              value="Ja"
              checked={form.childrenHome === "Ja"}
              onChange={handleChange}
            />
          </label>
          <label>
            Delvis
            <input
              type="radio"
              name="childrenHome"
              value="Delvis"
              checked={form.childrenHome === "Delvis"}
              onChange={handleChange}
            />
          </label>
          <label>
            Nej
            <input
              type="radio"
              name="childrenHome"
              value="Nej"
              checked={form.childrenHome === "Nej"}
              onChange={handleChange}
            />
          </label>
        </>
      )}


      <h3>Har du husdjur?</h3>
      <label>
        Ja
        <input
          type="radio"
          name="pets"
          value="husdjur"
          checked={form.pets === "husdjur"}
          onChange={handleChange}
        />
      </label>
      <label>
        Nej
        <input
          type="radio"
          name="pets"
          value=""
          checked={form.pets === ""}
          onChange={handleChange}
        />
      </label>

      {form.pets && (
        <>
          <p>Vilket/vilka djur är det?</p>

          <label>
            Hund
            <input
              type="checkbox"
              name="dog"
              checked={form.dog !== ''}
              onChange={handleChange}
            />
          </label>
          <label>
            Katt
            <input
              type="checkbox"
              name="cat"
              checked={form.cat !== ''}
              onChange={handleChange}
            />
          </label>
          <label>
            Fågel
            <input
              type="checkbox"
              name="bird"
              checked={form.bird !== ''}
              onChange={handleChange}
            />
          </label>
          <label>
            Häst
            <input
              type="checkbox"
              name="horse"
              checked={form.horse !== ''}
              onChange={handleChange}
            />
          </label>
          <label>
            Andra
            <input
              type="text"
              name="other"
              value={form.other}
              onChange={handleChange}
              placeholder="Ange andra husdjur"
            />
          </label>
        </>
      )}    </>
  );
}

function Section5({ form, handleChange }) {
  return (
    <>
      <h1>Skapa ett erbjudande om livsbyte (5)</h1>
      <h2>Nu till det svåraste, att presentera ditt livserbjudande. </h2>
      <h3>Skriv en kort, lockande presentation av dig själv och ditt liv:</h3>
      <textarea name="presentation"
        value={form.presentation}
        onChange={handleChange}
        placeholder="Skriv en presentation av livet du erbjuder!" />

      <h3>Och slutligen, skriv en lockande rubrik till din annons:</h3>
      <input type="text"
        name="headline"
        value={form.headline}
        onChange={handleChange} />

      &nbsp;
    </>
  );
}

function Section6({ form, handleChange, submitted }) {

  return (
    <>
      {!submitted &&
        (<>
          <h2>Vill du publicera din annons nu eller spara den till senare?</h2>
          <label>
            Publicera
            <input
              type="radio"
              name="adActive"
              value={true}
              checked={form.adActive === true}
              onChange={handleChange}
            />
          </label>

          <label>
            Spara
            <input
              type="radio"
              name="adActive"
              value={false}
              checked={form.adActive === false}
              onChange={handleChange}
            />
          </label>

          {form.adActive && (
            <>
              <h3>Välj ett slutdatum för din annons:</h3>
              <input
                type="date"
                name="endDate"
                value={form.endDate}
                onChange={handleChange}
              />
            </>
          )}
        </>)}
    </>
  );
}

function CreateAd() {
  const navigate = useNavigate();
  const { activeUser } = useContext(GlobalContext);
  const totalSections = 6;
  const defaultAd = {
    headline: "",
    county: "",
    dwelling: "",
    dwellingOther: "",
    occupation: "",
    relStatus: "",
    partnerInfo: "",
    childrenNum: "",
    childrenHome: "",
    pets: "",
    dog: "",
    cat: "",
    bird: "",
    horse: "",
    other: "",
    city: "",
    cityAlternative: "",
    forest: "",
    sea: "",
    culture: "",
    shopping: "",
    car: "",
    carInfo: "",
    children: "",
    hobbies: "",
    presentation: "",
    age: "",
    gender: "",
    adActive: false,
    endDate: "",
  };

  const [form, setForm] = useState(defaultAd);
  const [currentSection, setCurrentSection] = useState(1);
  const [message, setMessage] = useState("");
  const [submitted, setSubmitted] = useState(false);

  const handleChange = (event) => {
    const { name, value, type, checked } = event.target;
    let newValue = value;

    if (type === 'checkbox') {
      if (['dog', 'cat', 'bird', 'horse', 'forest', 'sea', 'culture', 'shopping'].includes(name)) {
        newValue = checked ? (name === 'sea' ? 'Hav / Sjö' : name) : '';
      } else {
        newValue = checked;
      }
    } else if (type === 'radio') {
      if (name === 'adActive') {
        newValue = value === 'true';
      }
    } else if (name === "age") {
      const numValue = parseInt(value, 10);
      if (isNaN(numValue) || numValue < 18 || numValue > 120) {
        alert("Ålder måste vara mellan 18 och 120");
        return;
      }
    }

    setForm(prevForm => ({
      ...prevForm,
      [name]: newValue,
    }));
  }

  const prevSection = () => {
    if (currentSection > 1) {
      setCurrentSection(currentSection - 1);
    }
  };

  const nextSection = () => {
    setCurrentSection(currentSection + 1);
  };

  const handleSubmit = async (event) => {
    event.preventDefault();

    if (!activeUser || !activeUser.Id) {
      console.error('Active user or user Id is missing.');
      return;
    }
    const EndTimestamp = new Date(form.endDate).getTime();

    const formDataWithId = {
      ...form,
      UserId: activeUser.Id,
      EndTimestamp,
    };

    const response = await fetch('/api/ads', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(formDataWithId),
    });

    if (response.ok) {

      const successMessage = form.adActive
        ? `Tack! Din annons har nu publicerats! Den är aktiv till och med ${form.endDate}. Lycka till med livsbytet!`
        : 'Din annons har sparats. Du kan publicera den när du vill på "Min sida"';
      setMessage(successMessage);
      //navigate('/');
    } else {
      console.error('Error saving data');
    }
    setSubmitted(true);
  };

  return (
    <form onSubmit={handleSubmit}>
      {currentSection === 1 && <Section1 form={form} handleChange={handleChange} />}
      {currentSection === 2 && <Section2 form={form} handleChange={handleChange} />}
      {currentSection === 3 && <Section3 form={form} handleChange={handleChange} />}
      {currentSection === 4 && <Section4 form={form} handleChange={handleChange} />}
      {currentSection === 5 && <Section5 form={form} handleChange={handleChange} />}
      {currentSection === 6 && <Section6 form={form} handleChange={handleChange} submitted={submitted} />}

      {message && <p>{message}</p>}

      <br />
      <br />
      {!submitted && (
        <>
          {currentSection > 1 && (
            <button value="Previous" type="button" onClick={prevSection}>Previous</button>
          )}

          {currentSection < totalSections && (
            <button value="Continue" type="button" onClick={nextSection}>Continue</button>
          )}

          {currentSection === totalSections && (
            <>
              <br />
              <button value="Submit" type="submit">Submit</button>
            </>
          )}
        </>
      )}
    </form>
  );
}

export default CreateAd;
