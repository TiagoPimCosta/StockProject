import { Routes, Route } from "react-router-dom";
import { useNavigate } from "react-router-dom";

import "./App.css";

import NewProduct from "./routes/newProduct";
import ProductList from "./routes/productList";
import Stock from "./routes/stock";

function App() {
  var navigate = useNavigate();

  function nextPath(path) {
    navigate(path);
  }

  return (
    <Routes>
      <Route path="/" element={<ProductList nextPath={nextPath} />} />
      <Route path="/newProduct" element={<NewProduct nextPath={nextPath} />} />
      <Route path="/stock/:name" element={<Stock nextPath={nextPath} />} />
    </Routes>
  );
}

export default App;
