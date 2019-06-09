<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
xmlns:User="ext:User">
  <xsl:param name="User:UserName" />
  <xsl:param name="User:Password" />

  <xsl:template match="/">
    <html>
      <head>
        <title>
          Welcome <xsl:value-of select="$User:UserName" />
        </title>
      </head>
      <body>
        <P>
          Dear <xsl:value-of select="$User:UserName" />,
        </P>
        Your Password is <b>
          <xsl:value-of select="$User:Password" />
        </b>
        <BR />
        <P>
          Regards
          MyService Administrator
        </P>

      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>