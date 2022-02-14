import { useNavigate } from 'react-router-dom';

function Router() {

  let navigate = useNavigate();

  export async function nextPath(path) {
    navigate(path);
  }

  return {nextPath}
}

export default Router;