<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
xmlns:UserDetails="ext:User"
	xmlns:Account="ext:Account">
	<xsl:template match="/">
		<html>
			<!--<head>
				<title>Welcome <xsl:value-of select="UserDetails:get_UserName()" /></title>
			</head>-->
			<body>
				<P>Dear <xsl:value-of select="UserDetails:get_UserName()" />,</P>
					Your Password is <xsl:value-of select="Account:get_AccountName()" />
          <BR />
					<BR />
					Please click on the following link to activate the account<BR />
					<a><xsl:attribute name="href">http://www.myservice.com/activateaccount.aspx?
					AccountName=<xsl:value-of select="Account:get_AccountName()" />&amp;
					ActivateFlag=1</xsl:attribute>Click Here To Activate
					</a>
				<P>
			Regards
			MyService Administrator
		</P>
				
				</body>
		</html>
	</xsl:template>
</xsl:stylesheet>