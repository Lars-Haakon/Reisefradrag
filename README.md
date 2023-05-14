# Reisefradrag

Løsningen bruker .NETs Minimal Api for å eksponere et Post endepunkt. 
Prosjektet var enkelt å sette opp og skulle vise seg å være enkelt og integrasjonsteste ved hjelp av WebApplicationFactory.

Utviklingsprosessen har vært test-drevet ved alltid å skrive nye enhetstester for nye regler som skulle implementeres.

Utfordringer som verdt å nevne er valg av datatyper til data-objektene, DI-injection for hvilken beregner som skal brukes og om man skal slå sammen arbeidsreiser og besøksreiser til samme type med en gang man får en forespørsel.

Under beregning av reisefradrag har jeg valgt å gå for decimal typen, siden det ikke nødvendigvis vil bli et rundt tall etter beregning for gitte input. Decimal er fin å bruke for å representere en pengesum siden man ikke kommer bort i avrundingsfeil.

Bruker rammeverkets DI-container for å angi hvilken type reisefradragsberegner som skal benyttes. Siden oppgaveteksten angir at reglene som var gitt gjaldt for 2017 er det laget en implementasjon for akkurat reglene som gjaldt i 2017, og trenger man en ny kan man implementere interfacet og bytte ut i container-oppsettet.

Har vært litt frem og tilbake på om arbeidsreiser og besøksreiser bare skulle blitt slått sammen til en egen "Reise"-klasse, siden det ikke er noen praktisk forskjell på disse typene slik som oppgaveteksten beskriver det. Har valgt å holde disse typene skilt med en baktanke om at det skal være lettere å vedlikeholde koden i tilfelle det skulle komme nye krav for den ene eller andre reise-typen.