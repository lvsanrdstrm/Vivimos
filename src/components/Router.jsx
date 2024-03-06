import { BrowserRouter, Routes, Route } from "react-router-dom"
import Home from "../pages/Home.jsx"
import Test from '../pages/Test.jsx'
import Userpage from '../pages/Userpage.jsx'
import Layout from "./Layout.jsx"
// import Header from "./Header.jsx"



function Router() {

  return (
    <BrowserRouter>
      <Layout> 
      <Routes>
        {/*<Route path="/" element={<Header />} />*/}
        
        <Route path="/" element={<Home />} /> {/*kan va självstängande element om det inte händer något mellan taggarna*/}
        <Route path="/test" element={<Test />} />
        <Route path="/user/:username" element={<Userpage />} />
      </Routes>
      </Layout>
    </BrowserRouter>
  )

}

export default Router