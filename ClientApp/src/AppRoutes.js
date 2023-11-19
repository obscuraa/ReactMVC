import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { CreateEllipsoid } from "./components/CreateEllipsoid";
import { Login } from "./components/Login";
import { Register } from "./components/Register";
//import { Request } from "./components/Request";

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/counter',
        element: <Counter />
    },
    {
        path: '/fetch-data',
        element: <FetchData />
    },
    {
        path: '/create-ellipsoid',
        element: <CreateEllipsoid />
    },
    {
        path: '/ellipsoid',
    },
    {
        path: '/register',
        element: <Register />
    },
    {
        path: '/login',
        element: <Login />
    }
    //,
    //{
    //    path: '/apptest',
    //    element: <Request />
    //}
];

export default AppRoutes;
