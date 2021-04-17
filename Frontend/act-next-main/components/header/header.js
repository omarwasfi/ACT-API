import React from "react";
import Logo from "../../public/images/logo.png";
import Restart from "../../public/images/restart.png";
import Docs from "../../public/images/docs.svg";
import axios from "axios";

import { useRouter } from "next/router";
import Link from "next/link";

import { apiPath } from "../apiPath/apiPath";

const Header = () => {
  const router = useRouter();

  const Config = {
    method: "POST",
  };

  const handleShutdown = () => {
    axios(`${apiPath}Shutdown/blow-me-up`)
      .then((res) => {
        console.log(res.data);
      })
      .catch((error) => {
        console.error("There was an error!", error);
      });
    router.push({
      pathname: `/shutdownDoc`,
    });
  };

  return (
    <header>
      <div className="container-lo">
        <div>
          <Link href="/">
            <a>
              <img src={Logo} alt="logo" />
            </a>
          </Link>
          <div>
            <Link href="https://localhost:5001/swagger/index.html">
              <a>
                <img
                  src={Docs}
                  style={{ width: "30px", height: "30px" }}
                  alt="docs"
                />
              </a>
            </Link>
            <img
              src={Restart}
              className="shutdown"
              alt="Restart"
              onClick={handleShutdown}
              style={{ width: "30px", height: "30px" }}
            />
          </div>
        </div>
      </div>
    </header>
  );
};

export default Header;
