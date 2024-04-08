import { BrowserRouter, Routes, Route, useParams } from "react-router-dom"
import Home from "../pages/Home.jsx"
import Ad from "../pages/Ad.jsx"
import ConfirmBid from '../components/ConfirmBid.jsx'
import Test from '../pages/Test.jsx'
import Userpage from '../pages/Userpage.jsx'
import Layout from "./Layout.jsx"
import AdDetailed from "./AdDetailed";
// import Header from "./Header.jsx"



function Router() {

  return (
    <BrowserRouter>
      <Layout>
      <Routes>
        {/*<Route path="/" element={<Header />} />*/}
        <Route path="/createAd" element={<Ad />} />
        <Route path="/ad/:id" element={<AdDetailed />} />
        <Route path='/ad/:id/bid' element={<ConfirmBid />} />
        <Route path="/" element={<Home />} /> {/*kan va självstängande element om det inte händer något mellan taggarna*/}
        <Route path="/test" element={<Test />} />
        <Route path="/users/:id" element={<Userpage />} />
      </Routes>
      </Layout>
    </BrowserRouter>
  )

}

export default Router