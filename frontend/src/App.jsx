import { BrowserRouter, Routes, Route } from "react-router-dom";

import './App.css';

import NewProduct from "./routes/newProduct";
import ProductList from "./routes/productList";
import Stock from "./routes/stock";

function App() {
  return (
    <BrowserRouter>
        <Routes>

          <Route path="/" element={<ProductList />} />
          <Route path="newProduct" element={<NewProduct />} />
          <Route path="stock" element={<Stock />}>
            <Route path=":name" />
          </Route>

        </Routes>
      </BrowserRouter>
  );
}

export default App;
