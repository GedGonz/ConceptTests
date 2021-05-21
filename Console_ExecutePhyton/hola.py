

def Saludo(name):
    print("Hola: " +name)



def Lista(lista):

   for element in lista:
        print("Id: "+str(element.id))
        print("Nombre: "+element.name)
        print("Appelido: "+element.lastname)



def ListaFiltrada(lista):

   lista2 = filter(lambda c :c.*field*==*value*, lista)

   return lista2