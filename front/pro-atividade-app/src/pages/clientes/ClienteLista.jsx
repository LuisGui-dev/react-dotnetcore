import { useState } from "react";
import TitlePage from "../../components/TitlePage";
import { useHistory } from "react-router-dom";
import { InputGroup, FormControl, Button } from "react-bootstrap";

const clientes = [
  {
    id: 1,
    nome: "Microsoft",
    resposnsavel: "Otto",
    contato: "10558441",
    situacao: "Ativo",
  },
  {
    id: 2,
    nome: "Amazom",
    resposnsavel: "layr",
    contato: "125469",
    situacao: "Ativo",
  },
  {
    id: 3,
    nome: "Google",
    resposnsavel: "kevim",
    contato: "99541238",
    situacao: "Desativado",
  },
  {
    id: 4,
    nome: "Facebook",
    resposnsavel: "Jessica",
    contato: "8452317",
    situacao: "Ativo",
  },
  {
    id: 5,
    nome: "Twiter",
    resposnsavel: "Jack",
    contato: "00226548",
    situacao: "Ativo",
  },
];

export default function ClienteLista() {
  const history = useHistory();
  const [termoBusca, setTermoBusca] = useState("");

  const handleInputChange = (e) => {
    setTermoBusca(e.target.value);
  };

  const clientesFiltrados = clientes.filter((cliente) => {
    return Object.values(cliente)
      .join(" ")
      .toLowerCase()
      .includes(termoBusca.toLowerCase());
  });

  const novoCliente = () => {
    history.push("/cliente/detalhe");
  };

  return (
    <>
      <TitlePage title="Cliente Lista">
        <Button variant="outline-secondary" onClick={novoCliente}>
          <i className="fas fa-plus me-2" />
          Novo Cliente
        </Button>
      </TitlePage>
      <InputGroup className="mt-3 mb-3">
        <InputGroup.Text>Buscar:</InputGroup.Text>
        <FormControl
          onChange={handleInputChange}
          placeholder="Bucar por nome do cliente"
        />
      </InputGroup>
      <table className="table table-striped table-hover">
        <thead className="table-dark mt-3">
          <tr>
            <th scope="col">#</th>
            <th scope="col">Nome</th>
            <th scope="col">Responsável</th>
            <th scope="col">Contato</th>
            <th scope="col">Situação</th>
            <th scope="col">Opções</th>
          </tr>
        </thead>
        <tbody>
          {clientesFiltrados.map((cliente) => (
            <tr key={cliente.id}>
              <td>{cliente.id}</td>
              <td>{cliente.nome}</td>
              <td>{cliente.resposnsavel}</td>
              <td>{cliente.contato}</td>
              <td>{cliente.situacao}</td>
              <td>
                <div>
                  <button
                    className="btn btn-sm btn-outline-primary me-2"
                    onClick={() =>
                      history.push(`/cliente/detalhe/${cliente.id}`)
                    }
                  >
                    <i className="fas fa-user-edit me-2" />
                    Editar
                  </button>
                  <button className="btn btn-sm btn-outline-danger me-2">
                    <i className="fas fa-user-times me-2" />
                    Desativar
                  </button>
                </div>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </>
  );
}
