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
          name="kön"
          value="Man"
          checked={form.kön === "Man"}
          onChange={handleChange}
        />
      </label>

      <label>
        Kvinna
        <input
          type="radio"
          name="kön"
          value="Kvinna"
          checked={form.kön === "Kvinna"}
          onChange={handleChange}
        />
      </label>

      <label>
        Annat
        <input
          type="radio"
          name="kön"
          value="Annat"
          checked={form.kön === "Annat"}
          onChange={handleChange}
        />
      </label>

      <h3>Hur gammal är du:</h3>
      <input
        type="number"
        name="ålder"
        value={form.ålder}
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
      <select name="län" value={form.län} onChange={handleChange}>
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
        <input type="radio" name="boende" value="Lägenhet" checked={form.boende === "Lägenhet"}
          onChange={handleChange} />
      </label>
      <label>
        Villa
        <input type="radio" name="boende" value="Villa" checked={form.boende === "Villa"} onChange={handleChange} />
      </label>
      <label>
        Gård
        <input type="radio" name="boende" value="Gård" checked={form.boende === "Gård"} onChange={handleChange} />
      </label>
      <label>
        Sommarstuga
        <input type="radio" name="boende" value="Sommarstuga" checked={form.boende === "Sommarstuga"}
          onChange={handleChange} />
      </label>
      <label>
        Husvagn
        <input type="radio" name="boende" value="Husvagn" checked={form.boende === "Husvagn"} onChange={handleChange} />
      </label>
      <label>
        Trappuppgång
        <input type="radio" name="boende" value="Trappuppgång" checked={form.boende === "Trappuppgång"}
          onChange={handleChange} />
      </label>
      <label>
        Annat, vilket?
        <input type="radio" name="boende" value="Annat" checked={form.boende === "Annat"} onChange={handleChange} />
        {form.boende === "Annat" && (
          <input type="text" name="boendeAnnat" value={form.boendeAnnat} onChange={handleChange}
            placeholder="Ange boende" />
        )}
      </label>
      <h3>Bor du i:</h3>
      <select name="stad" value={form.stad} onChange={handleChange}>
        <option value="">Välj...</option>
        <option value="Storstad">Storstad (100 000+)</option>
        <option value="Mellanstor stad">Mellanstor stad (20 000 - 100 000)</option>
        <option value="Småstad">Småstad (3 000 - 20 000)</option>
        <option value="By">By (3 000-)</option>
        <option value="Bystan">Bystan (befriat från grannar)</option>
      </select>

      {form.stad === "Storstad" || form.stad === "Mellanstor stad" ? (
        <select name="stadAlternativ" value={form.stadAlternativ} onChange={handleChange}>
          <option value="">Välj...</option>
          <option value="Centralt">Centralt</option>
          <option value="Villaförort">Villaförort</option>
          <option value="Betongförort">Betongförort</option>
        </select>
      ) : null}

      <h3>Ditt boende är:</h3>
      <label>
        Naturnära (skog)
        <input type="checkbox" name="Skog" checked={form.Skog !== ""} onChange={handleChange} />
      </label>
      <label>
        Naturnära (hav/sjö)
        <input type="checkbox" name="Hav" checked={form.Hav !== ""} onChange={handleChange} />
      </label>
      <label>
        Kulturnära (biografer, teater, muséer, gallerier)
        <input type="checkbox" name="Kultur" checked={form.Kultur !== ""} onChange={handleChange} />
      </label>
      <label>
        Shoppingnära
        <input type="checkbox" name="Shopping" checked={form.Shopping !== ""} onChange={handleChange} />
      </label>
      <h3>Har du bil?</h3>
      <label>
        Ja
        <input
          type="radio"
          name="bil"
          value="bil"
          checked={form.bil === "bil"}
          onChange={handleChange}
        />
      </label>
      <label>
        Nej
        <input
          type="radio"
          name="bil"
          value=""
          checked={form.bil === ""}
          onChange={handleChange}
        />
      </label>

      {form.bil && (
        <>
          <p>Märke/modell/år:</p>
          <input type="text"
            name="bilinfo"
            value={form.bilinfo}
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
        name="sysselsättning"
        value={form.sysselsättning}
        onChange={handleChange} />

      <h3>Vad gör du på fritiden? Skriv upp till fem fritidsintressen:</h3>
      <input type="text"
        name="fritidsintressen"
        value={form.fritidsintressen}
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
          name="relstatus"
          value="singel: ensamvarg"
          checked={form.relstatus === "singel: ensamvarg"}
          onChange={handleChange}
        />
      </label>
      <label>
        Singel på jakt
        <input
          type="radio"
          name="relstatus"
          value="singel"
          checked={form.relstatus === "singel"}
          onChange={handleChange}
        />
      </label>
      <label>
        I en öppen relation (särboende)
        <input
          type="radio"
          name="relstatus"
          value="öppen särbo"
          checked={form.relstatus === "öppen särbo"}
          onChange={handleChange}
        />
      </label>
      <label>
        I en exklusiv relation (särboende)
        <input
          type="radio"
          name="relstatus"
          value="exklusiv särbo"
          checked={form.relstatus === "exklusiv särbo"}
          onChange={handleChange}
        />
      </label>
      <label>
        I en öppen relation (samboende)
        <input
          type="radio"
          name="relstatus"
          value="öppen sambo"
          checked={form.relstatus === "öppen sambo"}
          onChange={handleChange}
        />
      </label>
      <label>
        I en exklusiv relation (samboende)
        <input
          type="radio"
          name="relstatus"
          value="exklusiv sambo"
          checked={form.relstatus === "exklusiv sambo"}
          onChange={handleChange}
        />
      </label>
      <label>
        I en polyrelation
        <input
          type="radio"
          name="relstatus"
          value="poly"
          checked={form.relstatus === "poly"}
          onChange={handleChange}
        />
      </label>
      <label>
        Det är lite knasigt
        <input
          type="radio"
          name="relstatus"
          value="knasigt"
          checked={form.relstatus === "knasigt"}
          onChange={handleChange}
        />
      </label>
      {!form.relstatus.includes("singel") && form.relstatus !== "" && (
        <>
          <p>Namn och ålder på din/a partner/s?:</p>
          <input type="text"
            name="partnerinfo"
            value={form.partnerinfo}
            onChange={handleChange} />
        </>
      )}
      <h3>Har du barn?</h3>
      <label>
        Ja
        <input
          type="radio"
          name="barn"
          value="barn"
          checked={form.barn === "barn"}
          onChange={handleChange}
        />
      </label>
      <label>
        Nej
        <input
          type="radio"
          name="barn"
          value=""
          checked={form.barn === ""}
          onChange={handleChange}
        />
      </label>
      {form.barn === "barn" && (
        <>
          <h3>Hur många?</h3>
          <input
            type="number"
            name="barnAntal"
            value={form.barnAntal}
            onChange={handleChange}
            min="1"
          />


          <h3>Bor de hos dig?</h3>
          <label>
            Ja
            <input
              type="radio"
              name="barnBoende"
              value="Ja"
              checked={form.barnBoende === "Ja"}
              onChange={handleChange}
            />
          </label>
          <label>
            Delvis
            <input
              type="radio"
              name="barnBoende"
              value="Delvis"
              checked={form.barnBoende === "Delvis"}
              onChange={handleChange}
            />
          </label>
          <label>
            Nej
            <input
              type="radio"
              name="barnBoende"
              value="Nej"
              checked={form.barnBoende === "Nej"}
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
          name="husdjur"
          value="husdjur"
          checked={form.husdjur === "husdjur"}
          onChange={handleChange}
        />
      </label>
      <label>
        Nej
        <input
          type="radio"
          name="husdjur"
          value=""
          checked={form.husdjur === ""}
          onChange={handleChange}
        />
      </label>

      {form.husdjur && (
        <>
          <p>Vilket/vilka djur är det?</p>

          <label>
            Hund
            <input
              type="checkbox"
              name="Hund"
              checked={form.Hund !== ''}
              onChange={handleChange}
            />
          </label>
          <label>
            Katt
            <input
              type="checkbox"
              name="Katt"
              checked={form.Katt !== ''}
              onChange={handleChange}
            />
          </label>
          <label>
            Fågel
            <input
              type="checkbox"
              name="Fågel"
              checked={form.Fågel !== ''}
              onChange={handleChange}
            />
          </label>
          <label>
            Häst
            <input
              type="checkbox"
              name="Häst"
              checked={form.Häst !== ''}
              onChange={handleChange}
            />
          </label>
          <label>
            Andra
            <input
              type="text"
              name="Annat"
              value={form.Annat}
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
        name="rubrik"
        value={form.rubrik}
        onChange={handleChange} />

      &nbsp;
    </>
  );
}
function Section6({ form, handleChange }) {
  return (
    <>
      <h2>Vill du publicera din annons nu eller spara den till senare?</h2>
      <label>
        Publicera
        <input
          type="radio"
          name="publicerad"
          value={true}
          checked={form.publicerad === true}
          onChange={handleChange}
        />
      </label>
      <label>
        Spara
        <input
          type="radio"
          name="publicerad"
          value={false}
          checked={form.publicerad === false}
          onChange={handleChange}
        />
      </label>
      {form.publicerad && (
        <>
          <h3>Välj ett slutdatum för din annons:</h3>
          <input
            type="date"
            name="enddate"
            value={form.enddate}
            onChange={handleChange}
          />
        </>
      )}
    </>
  );
}
function CreateAd() {
  const navigate = useNavigate()
  const { activeUser } = useContext(GlobalContext);
  const [formData, setFormData] = useState({});


  const totalSections = 6;
  const defaultAd = {

    rubrik: "",
    län: "",
    boende: "",
    boendeAnnat: "",
    sysselsättning: "",
    relstatus: "",
    partnerinfo: "",
    barnAntal: "",
    barnBoende: "",
    husdjur: "",
    Hund: "",
    Katt: "",
    Fågel: "",
    Häst: "",
    Annat: "",
    stad: "",
    stadAlternativ: "",
    Skog: "",
    Hav: "",
    Kultur: "",
    Shopping: "",
    bil: "",
    bilinfo: "",
    barn: "",
    fritidsintressen: "",
    presentation: "",
    ålder: "",
    kön: "",
    publicerad: false,
    enddate: "",
  };


  const [form, setForm] = useState(defaultAd);

  const handleChange = (event) => {
    const { name, value, type, checked } = event.target;
    let newValue = value;

    if (type === 'checkbox') {
      if (['Hund', 'Katt', 'Fågel', 'Häst', 'Skog', 'Hav', 'Kultur', 'Shopping'].includes(name)) {
        newValue = checked ? (name === 'Hav' ? 'Hav / Sjö' : name) : '';
      } else {
        newValue = checked;
      }
    } else if (type === 'radio') {
      if (name === 'publicerad') {
        newValue = value === 'true';
      }
    } else if (name === "ålder") {
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

  const [currentSection, setCurrentSection] = useState(1);

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

    const endTimestamp = new Date(form.enddate).getTime();

    //console.log('Form data:', form);
    //console.log(activeUser);

    const formDataWithId = {
      ...form,
      userId: activeUser.id,
      endTimestamp,
    };
    console.log('With user Id:', formDataWithId);

    // Om konvertera till objekt.
    // const info = Object.fromEntries(data);

    // GAMLA KODEN const response = await fetch('/api/ads', {
    //   method: 'POST',
    //   headers: {
    //     'Content-Type': 'application/json',
    //   },
    //   body: JSON.stringify(formDataWithId),

    // });

    async function postAd(formData) {
      try {
        const response = await fetch('/api/ads', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify(formData),
        });

        if (response.ok) {
          form.publicerad
            ? alert(`Tack! Din annons har nu publicerats! Den är aktiv till och med ${form.enddate}. Lycka till med livsbytet!`)
            : alert('Din annons har sparats. Du kan publicera den när du vill på "Min sida"');
          navigate('/');
        } else {
          console.error('Error saving data');
        }
      } catch (error) {
        console.error('Error:', error);
      }
    }

    // GAMLA KODEN if (response.ok) {
    //   form.publicerad
    //     ? alert(`Tack! Din annons har nu publicerats! Den är aktiv till och med ${form.enddate}. Lycka till med livsbytet!`)
    //     : alert('Din annons har sparats. Du kan publicera den när du vill på "Min sida"');
    //   navigate('/');
    // } else {
    //   console.error('Error saving data');
    // }


  };

  return (
    <form onSubmit={handleSubmit}>
      {currentSection === 1 && <Section1 form={form} handleChange={handleChange} />}
      {currentSection === 2 && <Section2 form={form} handleChange={handleChange} />}
      {currentSection === 3 && <Section3 form={form} handleChange={handleChange} />}
      {currentSection === 4 && <Section4 form={form} handleChange={handleChange} />}
      {currentSection === 5 && <Section5 form={form} handleChange={handleChange} />}
      {currentSection === 6 && <Section6 form={form} handleChange={handleChange} />}

      <br />
      <br />

      {currentSection > 1 && (
        <button type="button" onClick={prevSection}>Previous</button>
      )}

      {currentSection < totalSections && (
        <button type="button" onClick={nextSection}>Continue</button>
      )}

      {currentSection === totalSections && (
        <>
          <br />
          <button type="submit">Submit</button>
        </>
      )}
    </form>
  );
}

export default CreateAd;